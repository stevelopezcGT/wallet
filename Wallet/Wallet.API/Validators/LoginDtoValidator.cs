namespace Wallet.Api.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(m => m.UserName)
            .NotEmpty()
            .WithMessage(LanguageConst.InvalidUserName);

        RuleFor(m => m.Password)
            .NotEmpty()
            .MaximumLength(ValidationConst.MaxFieldLength)
            .WithMessage(LanguageConst.InvalidPassword);
    }
}