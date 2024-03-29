using Microsoft.Extensions.Configuration;
using MimeKit;
using StreamlineAcademy.Application.Abstractions.IEmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Text;
using System.Threading.Tasks;
using StreamlineAcademy.Domain.Models.Common;

namespace StreamlineAcademy.Application.Services
{
	public class EmailHelperService:IEmailHelperService
	{

		private readonly IConfiguration configuration;
		public EmailHelperService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task<bool> SendRegistrationEmail(string emailAddress, string name, string password)
		{
        
            var baseUrl = configuration.GetValue<string>("EmailSettings:DomainUrl");
            var subject = "Stramline Academies Registration";
            string body = "Hi " + name + ",<br /><br />Thank you for registering with Streamline academies. Please find your UserName and Password below<br /><br />"
                                        + "<strong>User Name:</strong>  " + emailAddress + "<br />"
                                        + "<strong>Password:</strong>  " + password + "<br />"
                                        + "Please Click Here to Login: " + baseUrl + "<br /><br />"
                                         + "Have a nice day...<br /><br />"
                                    + "Thanks,<br />"
                                    + "Team Streamline Academies";
            var emailMessage = CreateMailMessage(emailAddress, subject, body);
            return await SendRegistrationEmail(emailMessage);
        

		}
		private async Task<bool> SendRegistrationEmail(MimeMessage emailMessage)
		{
			var emailParameters = new EmailParameters();
			emailParameters.SmtpHost = configuration.GetValue<string>("EmailSettings:SmtpHost");
			emailParameters.Port = configuration.GetValue<int>("EmailSettings:Port");
			emailParameters.UserName = configuration.GetValue<string>("EmailSettings:RegisterMail");
			emailParameters.Password = configuration.GetValue<string>("EmailSettings:RegisterMailPassword");
			return await Send(emailMessage, emailParameters);
		}

		private async Task<bool> Send(MimeMessage email, EmailParameters emailParameters)
		{
			try
			{
				using var smtp = new SmtpClient();
				smtp.Connect(emailParameters.SmtpHost, emailParameters.Port, SecureSocketOptions.StartTls);
				smtp.Authenticate(emailParameters.UserName, emailParameters.Password);
				await smtp.SendAsync(email);
				smtp.Disconnect(true);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		private MimeMessage CreateMailMessage(string emailAddress, string Subject, string body)
		{
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(configuration.GetValue<string>("EmailSettings:From"));
			email.To.Add(MailboxAddress.Parse(emailAddress));
			email.Subject = Subject;
			var builder = new BodyBuilder();
			builder.HtmlBody = body;
			email.Body = builder.ToMessageBody();
			return email;
		}
	}
}
