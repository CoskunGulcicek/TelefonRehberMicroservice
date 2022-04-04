using MongoDB.Driver;
using Report.WebApi.Models;
using Report.WebApi.Settings;
using Mass = MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using Contact.Entities.Dtos.Contact;
using Contact.Entities.Dtos.ContactInformation;
using System.Data;
using System.IO;
using ClosedXML.Excel;
using DinkToPdf;
using Report.WebApi.Extensions;
using DinkToPdf.Contracts;
using Report.WebApi.Hubs.Business;

namespace Report.WebApi.Services
{
    public class ReportService : IReportService
    {
        private readonly IConverter _converter;
        private readonly IMongoCollection<Reports> _reportCollection;
        private readonly Mass.IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;
        private readonly ReportHubManager _reportHubManager;
        string baseAdress;
        public ReportService(IDatabaseSettings databaseSettings, Mass.IPublishEndpoint publishEndpoint, IMapper mapper, IHttpContextAccessor accessor, IConfiguration configuration, IConverter converter, ReportHubManager reportHubManager)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _reportCollection = database.GetCollection<Reports>(databaseSettings.ReportCollectionName);
            _publishEndpoint = publishEndpoint;
            _accessor = accessor;
            _configuration = configuration;
            _converter = converter;
            _reportHubManager = reportHubManager;
            baseAdress = _configuration["DatabaseSettings:ApiConnectionString"];
        }

        public async Task<Reports> CreateAsync(Reports reports)
        {
            var newReport = _mapper.Map<Reports>(reports);
            newReport.CreatedTime = DateTime.Now;


            #region 
            //Burada Contact Api'ye istek atacağım gelen sonucu excele çevireceğim
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"{baseAdress}ContactInformations/location?location={newReport.Location}");
            List<ContactInformationGetDto> contacts = new List<ContactInformationGetDto>();
            if (responseMessage.IsSuccessStatusCode)
            {
                contacts = JsonConvert.DeserializeObject<List<ContactInformationGetDto>>(await responseMessage.Content.ReadAsStringAsync());
            }
            #endregion


            #region 
            //SignalR ile ön tarafa veri gönderme
            if (contacts.Count > 0)
            {
                #region PDF OLUŞTURMA İŞLEMLERİ
                var newName = Guid.NewGuid() + ".pdf";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/" + newName);
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = path //tarayıcıda görüntülemek için out'u kapat
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = TemplateGenerator.GetHtmlString(contacts),
                    //Page = "http://cg.com"//sayfayı pdfte göstermek için kullanılır
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets", "styles.css") },
                    //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [Page] of [toPage]", Line = true },
                    FooterSettings = {
                    FontName = "Helvetica",
                    FontSize = 7,
                    Line = false,
                    Center = "",
                    Right = "Page [Page] of [toPage]",
                    Spacing = 5
                }
                };
                var pdf = new HtmlToPdfDocument
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                _converter.Convert(pdf);
                #endregion                        

                newReport.FileName = newName;
                newReport.FilePath = path;
                await _reportCollection.InsertOneAsync(newReport);

                await _reportHubManager.SendReportsAsync(newReport);
            }
            #endregion
            return newReport;
        }

        public async Task DeleteAsync(string id)
        {
            var result = await _reportCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<Reports>> GetAllAsync()
        {
            var reports = await _reportCollection.Find(course => true).ToListAsync();

            if (reports.Any())
            {
                return reports;
            }
            else
            {
                return  new List<Reports>();
            }
        }

        public async Task<List<Reports>> GetAllByLocationAsync(string location)
        {
            var reports = await _reportCollection.Find(x=>x.Location==location).ToListAsync();

            if (reports.Any())
            {
                return reports;
            }
            else
            {
                return new List<Reports>();
            }
        }

        public async Task<Reports> GetByIdAsync(string id)
        {
            var course = await _reportCollection.Find<Reports>(x => x.Id == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return new Reports();
            }
            return course;
        }
    }
}
