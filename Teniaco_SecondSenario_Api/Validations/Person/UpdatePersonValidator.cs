using FluentValidation;
using Teniaco_SecondSenario_Api.Models.Dtos.Person;

namespace Teniaco_SecondSenario_Api.Validations.Person
{
    public class UpdatePersonValidator: AbstractValidator<CreatePersonDto>
    {
        public UpdatePersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Is Requrid");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName Is Requrid");
            RuleFor(x => x.Mobile).NotEmpty().WithMessage("Mobile Is Requrid");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage("BirthDay Is Requrid");
        }
    }
}
