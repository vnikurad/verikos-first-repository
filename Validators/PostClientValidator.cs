using AldagiTPL.Models.Clients;
using FluentValidation;

namespace AldagiTPL.Validators
{
    public class PostClientValidator: AbstractValidator<AddClient>
    {
        public PostClientValidator()
        {
            RuleFor(reg => reg.FirstName).NotEmpty();
            RuleFor(reg => reg.LastName).NotEmpty();
            RuleFor(reg => reg.PersonalNumber).NotNull().NotEmpty().Matches("^([0-9]{11})$").WithMessage("Max length 11 characters.");
            RuleFor(reg => reg.DateOfBirth).NotEmpty();
            RuleFor(reg => reg.Phone).NotNull().NotEmpty().Matches("^((5)[0-9]{8})$").WithMessage("Phone number must be 5********");
            RuleFor(reg => reg.Email).EmailAddress();
        }
    }
}
