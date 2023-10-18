using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teniaco_SecondSenario_Api.Models.Entities.Person
{
    public class Person
    {
        [Key]
        public Int64 Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string? Mobile { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
