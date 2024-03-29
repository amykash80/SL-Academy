using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Abstractions.IEmailService
{
	public interface IEmailHelperService
	{

		Task<bool> SendRegistrationEmail(string emailAddress, string name, string password);
		//Task<bool> SendChangePasswordEmail(string emailAddress, string name, string password);


	}
}
