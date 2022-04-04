using Contact.Entities.Dtos.ContactInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.WebApi.Extensions
{
    public static class TemplateGenerator
    {
        public static string GetHtmlString(List<ContactInformationGetDto> contactInformationGetDtos )
        {
            string type = "";
            var sb = new StringBuilder();
            
            sb.Append(@"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                                <meta charset = 'UTF-8' >
                                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                <title> Document </title >
                            </head>
                            <body>
                          <center>");
            foreach (var item in contactInformationGetDtos)
            {
                sb.Append($"Location Name: {item.Location}, Name: {item.Name}, SurName: {item.SurName}<br>");
            }
            sb.Append(@"</center></body>
                        </html>");

            return sb.ToString();
        }

    }
}
