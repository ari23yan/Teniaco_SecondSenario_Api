﻿namespace Teniaco_SecondSenario_Api.Models.Dtos.Person
{
    public class CreatePersonDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Mobile { get; set; }
        public string BirthDay { get; set; }
    }
}
