using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Shared.Messages
{
    public class CreateReportMessageCommand
    {
        public string Location { get; set; }
        public DateTime CreatedTime { get; set; }    
    }
}
