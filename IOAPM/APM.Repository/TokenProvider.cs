using Microsoft.IdentityModel.Tokens;
using APM.Entities.Entities;
using APM.Repository.Contracts;
using APM.Repository.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APM.Repository
{
    public class TokenProvider : GenericRepository<Employee>, ITokenProvider
    {
        private const string key = "o6mdyw936gcbru2ksjz3260pkmi2ksyx";
        public TokenProvider(IUnitOfWork uow)
            : base(uow)
        {

        }

        public string LoginUser(string Email, string Password)
        {
            var user = GetUsers().SingleOrDefault(x => x.EMAIL == Email);

            if (user == null)
                return null;

            if (Password == user.PASSWORD)
            {
                var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
                var JWToken = new JwtSecurityToken(
                    issuer: "http://localhost:45092/",
                    audience: "http://localhost:45092/",
                    claims: GetUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddMinutes(500)).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }

        private List<UserDto> GetUsers()
        {
            var users = _context.Employees.Select(e => new UserDto
            {
                ID = e.ID.ToString(),
                NAME = e.EMPLOYEE_NAME,
                SURNAME = e.EMPLOYEE_SURNAME,
                EMAIL = e.EMPLOYEE_MAIL,
                PASSWORD = e.PASSWORD,
                ROLE = e.ROLE,
                ADRESS = e.EMPLOYEE_ADRESS
            }).ToList();

            return users;
        }

        private IEnumerable<Claim> GetUserClaims(UserDto user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.NAME);
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Surname, user.SURNAME);
            claims.Add(_claim);
            _claim = new Claim("ID", user.ID);
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Email, user.EMAIL);
            claims.Add(_claim);
            _claim = new Claim("ADRESS", user.ADRESS);
            claims.Add(_claim);
            _claim = new Claim(user.ROLE, user.ROLE);
            claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }

        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }


    }
}
