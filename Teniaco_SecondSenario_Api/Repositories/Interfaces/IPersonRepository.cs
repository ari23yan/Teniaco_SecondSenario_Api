using Teniaco_SecondSenario_Api.Models.Common;
using Teniaco_SecondSenario_Api.Models.Dtos.Person;
using Teniaco_SecondSenario_Api.Models.Entities.Person;

namespace Teniaco_SecondSenario_Api.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<ApiResponse<Int64>> CreatePerson(CreatePersonDto dto);
        Task<ApiResponse<bool>> UpdatePerson(long id ,UpdatePersonDto dto);
        Task<ApiResponse<bool>> DeletePerson(long id);
        Task<ApiResponse<PersonDto>> GetPerson(long id);
        Task<bool> CheckPersonExist(string Mobile);
        Task<ApiResponse<List<PersonDto>>> GetPersons();



    }
}
