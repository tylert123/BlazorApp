using Microsoft.AspNetCore.Identity.UI.Services;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;

namespace HiddenVilla_API.Helper
{
    public class EmailSender : IEmailSender
    {
        private readonly MailJetSettings _mailJetSettings;

        public EmailSender(IOptions<MailJetSettings> mailjetSettings)
        {
            _mailJetSettings = mailjetSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient(_mailJetSettings.PublicKey, _mailJetSettings.PrivateKey);
            //{
            //    Version = ApiVersion.V3_1,
            //};
            MailjetRequest request = new MailjetRequest
            {
                Resource = SendV31.Resource,
            }
             .Property(Send.Messages, new JArray {
                 new JObject {
                  {"From", new JObject {
                    {"Email", _mailJetSettings.Email},
                    {"Name", "Tyler"}
                   }}, 
                   {"To", new JArray {
                    new JObject {
                     {"Email", email}, 
                     {"Name", "Tyler"}
                    }
                   }},
                   {"Subject", subject}, 
                   {"HTMLPart", htmlMessage}
                 }
             });
            MailjetResponse response = await client.PostAsync(request);
            
        }
    }
}
