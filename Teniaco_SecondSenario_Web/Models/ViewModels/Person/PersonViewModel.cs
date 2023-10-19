namespace Teniaco_SecondSenario_Web.Models.ViewModels.Person
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Mobile { get; set; }
        public string BirthDay { get; set; }
        public string CreatedTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
