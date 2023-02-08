using CodeAcademyFinalExam.DTO;

namespace CodeAcademyFinalExam.DAL
{
    public interface IHumanInformationDbRepository
    {
        void AddNewUserToList(int accId, HumanInformationDto HumanDto);
        void UpdateUserById(int id, string name, string surname, string personalCode, string phone, string email);

        
    }
}
