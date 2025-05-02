namespace Wallet.Api.Validators;

public class CreateWalletDtoValidator : AbstractValidator<CreateWalletDto>
{
    public CreateWalletDtoValidator()
    {
        RuleFor(m => m.DocumentId)
            .NotEmpty()
            .WithMessage(LanguageConst.InvalidDocumentId);

        RuleFor(m => m.Name)
            .NotEmpty()
            .MaximumLength(ValidationConst.MaxFieldLength)
            .WithMessage(LanguageConst.InvalidName);
    }
}