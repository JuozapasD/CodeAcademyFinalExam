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
                Address = new Address
                {
                    City = HumanDto.Address.City,
                    Street = HumanDto.Address.Street,
                    HouseNumber = HumanDto.Address.HouseNumber,
                    FlatNumber = HumanDto.Address.FlatNumber,
                },
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
        public List<AccountInfoDto> GetAllAccounts()
        {
            return _context.Accounts.Select(x => new AccountInfoDto
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

        public IEnumerable<AccountDto> GetAllUserInfo()
        {
            var accounts = _context.Accounts.Include(b => b.HumanInformation).ThenInclude(b => b.Address).ToList();
            List<AccountDto> accountDtos = new List<AccountDto>();
            foreach (var acc in accounts)
            {
                if (acc.HumanInformation != null)
                {
                    var humanInfo = acc.HumanInformation;
                    if (humanInfo.Address != null)
                    {
                        var address = humanInfo.Address;
                        var accountDto = new AccountDto
                        {
                            Username = acc.Username,
                            Role = acc.Role,
                            HumanInformation = new HumanInformationDto
                            {
                                Name = humanInfo.Name,
                                Surname = humanInfo.Surname,
                                PersonalCode = humanInfo.PersonalCode,
                                TelephoneNumber = humanInfo.TelephoneNumber,
                                Email = humanInfo.Email,
                                Address = new AddressDto
                                {
                                    City = address.City,
                                    Street = address.Street,
                                    HouseNumber = address.HouseNumber,
                                    FlatNumber = address.FlatNumber
                                }
                            }
                        };
                        accountDtos.Add(accountDto);
                    }
                    else
                    {
                        var accountDto = new AccountDto
                        {
                            Username = acc.Username,
                            Role = acc.Role,
                            HumanInformation = new HumanInformationDto
                            {
                                Name = humanInfo.Name,
                                Surname = humanInfo.Surname,
                                PersonalCode = humanInfo.PersonalCode,
                                TelephoneNumber = humanInfo.TelephoneNumber,
                                Email = humanInfo.Email,
                                Address = null
                            }
                        };
                        accountDtos.Add(accountDto);
                    }
                }
                else
                {
                    var accountDto = new AccountDto
                    {
                        Username = acc.Username,
                        Role = acc.Role,
                        HumanInformation = null
                    };
                    accountDtos.Add(accountDto);
                }
            }

            return accountDtos;
        }

        public AccountDto GetUserInformationById(int userId)
        {
            var account = _context.Accounts
                .Include(b => b.HumanInformation)
                .ThenInclude(b => b.Address)
                .FirstOrDefault(a => a.Id == userId);

            if (account == null)
            {
                return null;
            }

            var humanInfo = account.HumanInformation;
            var address = humanInfo.Address;
            var accountDto = new AccountDto
            {
                Username = account.Username,
                Role = account.Role,
                HumanInformation = new HumanInformationDto
                {
                    Name = humanInfo.Name,
                    Surname = humanInfo.Surname,
                    PersonalCode = humanInfo.PersonalCode,
                    TelephoneNumber = humanInfo.TelephoneNumber,
                    Email = humanInfo.Email,
                    Address = new AddressDto
                    {
                        City = address.City,
                        Street = address.Street,
                        HouseNumber = address.HouseNumber,
                        FlatNumber = address.FlatNumber
                    }
                }
            };

            return accountDto;
        }


    }
}
