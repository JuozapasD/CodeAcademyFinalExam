using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAcademyFinalExam.DTO
{
    public class AccountDto
    {
        [Required]
        public string Username { get; set; }

        public string Role { get; set; }

        //Cia internet fix test, nes nenoriu, kad endpointa pasiektu info apie informacija, kuri nera pateikta
        //Siuo metu tokia info nueina kaip NULL

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HumanInformationDto HumanInformation { get; internal set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public AddressDto Address { get; internal set; }

        public static AccountDto FromAccount(Account account)
        {
            if (account == null)
            {
                return null;
            }

            var accountDto = new AccountDto
            {
                Username = account.Username,
                Role = account.Role
            };

            if (account.HumanInformation != null)
            {
                accountDto.HumanInformation = new HumanInformationDto
                {
                    Name = account.HumanInformation.Name,
                    Surname = account.HumanInformation.Surname,
                    PersonalCode = account.HumanInformation.PersonalCode,
                    TelephoneNumber = account.HumanInformation.TelephoneNumber,
                    Email = account.HumanInformation.Email
                };

                if (account.HumanInformation.Address != null)
                {
                    accountDto.Address = new AddressDto
                    {
                        City = account.HumanInformation.Address.City,
                        Street = account.HumanInformation.Address.Street,
                        HouseNumber = account.HumanInformation.Address.HouseNumber,
                        FlatNumber = account.HumanInformation.Address.FlatNumber
                    };
                }
            }

            return accountDto;
        }

    }
}
