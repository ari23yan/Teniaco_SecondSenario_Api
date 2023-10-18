namespace Teniaco_SecondSenario_Api.Models.Dtos.Person
{
    public class UpdatePersonDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Mobile { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
