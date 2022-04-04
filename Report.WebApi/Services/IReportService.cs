using Report.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebApi.Services
{
    public interface IReportService
    {
        Task<Reports> CreateAsync(Reports reports);
        Task<Reports> GetByIdAsync(string id);
        Task<List<Reports>> GetAllAsync();
        Task<List<Reports>> GetAllByLocationAsync(string location);
        Task DeleteAsync(string id);
    }
}
