using Contact.Web.ApiServices.Interfaces;
using Contact.Web.Models.Contact;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Contact.Web.ApiServices.Concrete
{
    public class IContactManager : IContactService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;
        string baseAdress;
        public IContactManager(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
            baseAdress = _configuration["ConnectionStrings:ApiConnectionString"];
        }

        public async Task<List<ContactGetDto>> GetAllAsync()
        {
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"{baseAdress}Contacts");

            if (responseMessage.IsSuccessStatusCode)
            {
                var contacts = JsonConvert.DeserializeObject<List<ContactGetDto>>(await responseMessage.Content.ReadAsStringAsync());
                return contacts;
            }
            return null;
        }

        public async Task<ContactGetDto> GetByIdAsync(Guid uuid)
        {
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"{baseAdress}Contacts/{uuid}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var contact = JsonConvert.DeserializeObject<ContactGetDto>(await responseMessage.Content.ReadAsStringAsync());

                return contact;
            }
            return null;
        }
    }
}
