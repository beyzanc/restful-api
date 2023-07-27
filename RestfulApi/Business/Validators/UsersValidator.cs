using FluentValidation;
using RestfulApi.Models;

namespace RestfulApi.Business.Validators
{
    public class UsersValidator : AbstractValidator<User>
    {
        public UsersValidator()
        {

            RuleFor(u => u.Username).NotEmpty().WithMessage("Please provide a username.")
                .MinimumLength(6).WithMessage("The username can not be less than 6 characters.")
                .MaximumLength(12).WithMessage("The username can not be more than 18 characters.")
                .Must(BeValidUsername).WithMessage("The username must include only letters, numbers and underscores.");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Please provide a password.")
                .MinimumLength(8).WithMessage("Password can not be less than 8 characters.")
                .MaximumLength(20).WithMessage("Password can not be higher than 20 characters.")
                .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$")
                .WithMessage("Password must contain at least one letter, one number, and one special character (@, $, !, %, *, ?, &).");

        }

        private bool BeValidUsername(string username)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-zA-Z0-9_]+$");
        }
    }
}
