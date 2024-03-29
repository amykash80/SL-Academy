using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamlineAcademy.Application.Utils
{
    public class AppEncryption
    {
		public static string GenerateSalt()
		{
			var randomNum = RandomNumberGenerator.GetBytes(16);
			return Convert.ToBase64String(randomNum);
		}
	     public static string CreatePassword(string password, string salt)
		{
			var PasswordWithSalt = string.Concat(password, salt);
			var sha = SHA256.Create();
			var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(PasswordWithSalt!));
			return Convert.ToBase64String(bytes);
		}
		public static bool ComparePassword(string hashPassword, string password, string salt)
		{
			return hashPassword == CreatePassword(password, salt);
		}
	}
}
