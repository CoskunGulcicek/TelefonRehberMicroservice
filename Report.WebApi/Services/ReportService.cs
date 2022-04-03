using MongoDB.Driver;
using Report.WebApi.Models;
using Report.WebApi.Settings;
using Mass = MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Report.WebApi.Services
{
    public class ReportService : IReportService
    {
        private readonly IMongoCollection<Reports> _reportCollection;
        private readonly Mass.IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public ReportService(IDatabaseSettings databaseSettings, Mass.IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _reportCollection = database.GetCollection<Reports>(databaseSettings.ReportCollectionName);
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Reports> CreateAsync(Reports reports)
        {
            var newCourse = _mapper.Map<Reports>(reports);
            newCourse.CreatedTime = DateTime.Now;
            await _reportCollection.InsertOneAsync(newCourse);
            return newCourse;
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
