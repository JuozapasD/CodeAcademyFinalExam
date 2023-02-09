using CodeAcademyFinalExam.DTO;
using Microsoft.EntityFrameworkCore;

namespace CodeAcademyFinalExam.DAL
{
    public class HumanInformationDbRepository : IHumanInformationDbRepository
    {
        

        private readonly AccountsRegistrationDbContext _context;
        
        public HumanInformationDbRepository(AccountsRegistrationDbContext context)
        {
            _context = context;
        }
        public void AddNewUserToList(int id, HumanInformationDto HumanDto)
        {

            var userFromDb = _context.Accounts.FirstOrDefault(i => i.Id == id);
            //var accountFromDb = _context.Accounts.FirstOrDefault(a => a.Id == userFromDb.HumanInformationId);
            //accountFromDb.HumanInformationId = userFromDb.HumanInformationId;

            userFromDb.HumanInformation = new HumanInformation
            {
                Name = HumanDto.Name,
                Surname = HumanDto.Surname,
                PersonalCode = HumanDto.PersonalCode,
                TelephoneNumber = HumanDto.TelephoneNumber,
                Email = HumanDto.Email,
                Address = HumanDto.Address,
            };


            _context.SaveChanges();

        }

        public void UpdateUserById(int accId, string name, string surname,
            string personalCode, string phone, string email,
            string city, string street, string houseNumber, string flatNumber)
        {
            var userFromDb = _context.Accounts.Include(b => b.HumanInformation).ThenInclude(b => b.Address).FirstOrDefault(i => i.Id == accId);
            userFromDb.HumanInformation.Name = name;
            userFromDb.HumanInformation.Surname = surname;
            userFromDb.HumanInformation.PersonalCode = personalCode;
            userFromDb.HumanInformation.TelephoneNumber = phone;
            userFromDb.HumanInformation.Email = email;

            userFromDb.HumanInformation.Address.City = city;
            userFromDb.HumanInformation.Address.Street = street;
            userFromDb.HumanInformation.Address.HouseNumber = houseNumber;
            userFromDb.HumanInformation.Address.FlatNumber = flatNumber;

            //var accountFromDb = _context.Accounts.FirstOrDefault(a => a.HumanInformationId == userFromDb.HumanInformationId);
           // accountFromDb.HumanInformationId = userFromDb.HumanInformationId;
            _context.SaveChanges();
        }
        public List<AccountDto> GetAllAccounts()
        {
            return _context.Accounts.Select(x => new AccountDto
            {
                Username = x.Username,
                Role = x.Role,
            }).ToList();
        }

        public void DeleteUserById(int id)
        {
            _context.Accounts.Remove(new Account { Id = id });
            _context.SaveChanges(true);
        }
    }
}
