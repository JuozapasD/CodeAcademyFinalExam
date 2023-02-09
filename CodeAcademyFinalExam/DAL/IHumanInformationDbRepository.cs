using CodeAcademyFinalExam.DTO;

namespace CodeAcademyFinalExam.DAL
{
    public interface IHumanInformationDbRepository
    {
        void AddNewUserToList(int id, HumanInformationDto HumanDto);
        void UpdateUserById(int id, string name, string surname,
            string personalCode, string phone, string email,
            string city, string street, string houseNumber, string flatNumber);
        public List<AccountDto> GetAllAccounts();
        public void DeleteUserById(int id);


    }
}
