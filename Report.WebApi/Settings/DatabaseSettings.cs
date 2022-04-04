using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Report.WebApi.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ReportCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
