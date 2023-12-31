﻿using System.ComponentModel.DataAnnotations;

namespace Teniaco_SecondSenario_Api.Models.Dtos.Person
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Mobile { get; set; }
        public string BirthDay { get; set; }
        public string CreatedTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
