namespace Wallet.Api.Validators;

public class UpdateWalletDtoValidator : AbstractValidator<UpdateWalletDto>
{
    public UpdateWalletDtoValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage(LanguageConst.InvalidWalletId);

        RuleFor(m => m.DocumentId)
            .NotEmpty()
            .WithMessage(LanguageConst.InvalidDocumentId);

        RuleFor(m => m.Name)
            .NotEmpty()
            .MaximumLength(ValidationConst.MaxFieldLength)
            .WithMessage(LanguageConst.InvalidName);
    }
}