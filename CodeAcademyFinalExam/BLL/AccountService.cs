using CodeAcademyFinalExam.DAL;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CodeAcademyFinalExam.BLL
{
    public class AccountService : IAccountService
    {
        private readonly IJwtRepository _jwtRepository;
        private readonly AccountsRegistrationDbContext _context;

        public AccountService(IJwtRepository jwtRepository, AccountsRegistrationDbContext context)
        {
            _jwtRepository = jwtRepository;
            _context = context;
        }

        public (bool, Account) Login(string username, string password)
        {
            var account = _jwtRepository.GetAccount(username);
            if (account == null)
            {
                return (false, null);
            }
            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return (true, account);
            }
            else
            {
                return (false, null);
            }

        }

        public Account SignupNewAccount(string username, string password)
        {
            if (_context.DoesUserExist(username))
            {
                throw new Exception("Username already in use");
            }
            var account = CreateAccount(username, password);
            _jwtRepository.SaveAccount(account);
            return account;
        }

        private Account CreateAccount(string username, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var account = new Account
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "User"
            };
            return account;

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

    }
}

