using Teniaco_SecondSenario_Api.Models.Common;
using Teniaco_SecondSenario_Web.Models.ViewModels.Person;

namespace Teniaco_SecondSenario_Web.WebServices.Person.Interfaces
{
    public interface IPersonService
    {
        Task<Int64> CreatePerson(CreatePersonViewModel dto);
        Task<bool> UpdatePerson(long id, UpdatePersonViewModel dto);
        Task<bool> DeletePerson(long id);
        Task<PersonViewModel> GetPerson(long id);
        Task<List<PersonViewModel>> GetPersons();
    }
}
