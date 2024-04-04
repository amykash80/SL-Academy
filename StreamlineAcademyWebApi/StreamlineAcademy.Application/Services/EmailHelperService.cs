﻿using Microsoft.Extensions.Configuration;
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
using StreamlineAcademy.Application.Abstractions.IServices;
using StreamlineAcademy.Application.Shared;

namespace StreamlineAcademy.Application.Services
{
	public class EmailHelperService:IEmailHelperService
	{

		private readonly IConfiguration configuration;
        private readonly IEmailTempelateRenderer emailTempelateRenderer;

        public EmailHelperService(IConfiguration configuration,
			                      IEmailTempelateRenderer emailTempelateRenderer)
		{
			this.configuration = configuration;
            this.emailTempelateRenderer = emailTempelateRenderer;
        }

		public async Task<bool> SendRegistrationEmail(string emailAddress, string name, string password)
		{
        
            var baseUrl = configuration.GetValue<string>("EmailSettings:DomainUrl");
            var subject = "Stramline Academies Registration";
            string body = await emailTempelateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.AcademyRegistration, new
            {
                Name = name,
                Email = emailAddress,
				CompanyName=APIMessages.ProjectName,
                Password = password,
            });
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
			var res= await Send(emailMessage, emailParameters);
			return res;
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

        public async Task<bool> SendResetPasswordEmail(string emailAddress)
        {
            var baseUrl = configuration.GetValue<string>("EmailSettings:DomainUrl");
            var subject = "Stramline Academies Reset Password";
            string body = await emailTempelateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.PasswordReset, new
            {
                CompanyName = APIMessages.ProjectName,
            });
            var emailMessage = CreateMailMessage(emailAddress, subject, body);
            return await SendRegistrationEmail(emailMessage);
        }
    }
}
