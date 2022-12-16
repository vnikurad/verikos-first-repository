using AldagiTPL.Models.TPLRequest;
using FluentValidation;

namespace AldagiTPL.Validators
{
    public class PutTPLRequestValidator: AbstractValidator<EditTPLRequest>
    {
        public PutTPLRequestValidator()
        {
            RuleFor(reg => reg.StatusId).GreaterThan(0);
            RuleFor(reg => reg.LimitId).GreaterThan(0);
            RuleFor(reg => reg.Client.FirstName).NotEmpty();
            RuleFor(reg => reg.Client.LastName).NotEmpty();
            RuleFor(reg => reg.Client.PersonalNumber).NotNull().NotEmpty().Matches("^[0-9]{11})$").WithMessage("Max length 11 characters.");
            RuleFor(reg => reg.Client.DateOfBirth).NotEmpty();
            RuleFor(reg => reg.Client.Phone).NotNull().NotEmpty().Matches("^((5)[0-9]{8})$").WithMessage("Phone number must be 5********");
            RuleFor(reg => reg.Client.Email).EmailAddress();
        }
    }
}
