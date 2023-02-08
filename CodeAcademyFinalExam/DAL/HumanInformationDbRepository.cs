using CodeAcademyFinalExam.DTO;

namespace CodeAcademyFinalExam.DAL
{
    public class HumanInformationDbRepository : IHumanInformationDbRepository
    {
        

        private readonly AccountsRegistrationDbContext _context;
        
        public HumanInformationDbRepository(AccountsRegistrationDbContext context)
        {
            _context = context;
        }
        public void AddNewUserToList(int accId, HumanInformationDto HumanDto) // cia i param turi ateiti account ID
        {

            var userFromDb = _context.Accounts.FirstOrDefault(i => i.Id == accId);
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

        public void UpdateUserById(int id, string name, string surname, string personalCode, string phone, string email)
        {
            var userFromDb = _context.HumanInformation.FirstOrDefault(i => i.AddressId == id);
            userFromDb.Name = name;
            userFromDb.Surname = surname;
            userFromDb.PersonalCode = personalCode;
            userFromDb.TelephoneNumber = phone;
            userFromDb.Email = email;
     
            _context.SaveChanges();
        }
    }
}
