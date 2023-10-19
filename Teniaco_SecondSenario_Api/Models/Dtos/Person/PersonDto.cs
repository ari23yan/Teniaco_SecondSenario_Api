using System.ComponentModel.DataAnnotations;

namespace Teniaco_SecondSenario_Api.Models.Dtos.Person
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Mobile { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
