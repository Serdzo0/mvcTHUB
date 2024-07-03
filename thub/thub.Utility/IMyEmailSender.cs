using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thub.Utility
{
    public interface IMyEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
        Task SendEmailWithTemplateAsync(string email, string templateId, object dynamicTemplateData);
    }
}
