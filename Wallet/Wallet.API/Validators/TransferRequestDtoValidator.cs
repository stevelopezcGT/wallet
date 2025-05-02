namespace Wallet.Api.Validators;

public class TransferRequestDtoValidator : AbstractValidator<TransactionRequestDto>
{
    public TransferRequestDtoValidator()
    {
        RuleFor(m => m.TransactionType)
            .NotEmpty()
            .IsInEnum()
            .WithMessage(LanguageConst.InvalidTransactionType);

        RuleFor(m => m.Amount)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage(LanguageConst.InvalidAmount);
    }
}