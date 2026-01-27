using FluentValidation;

namespace Ordering.Application.Features.Commands.UpdateOrder;

public sealed class UpdateOrderCommandValidator
    : AbstractValidator<UpdateOrderCommand>
{
    private const int NameMaxLength = 50;
    private const int ZipCodeMaxLength = 20;
    private const int CvvMinLength = 3;
    private const int CvvMaxLength = 4;
    
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        When(x => x.UserName is not null, () =>
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        });

        When(x => x.FirstName is not null, () =>
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        });

        When(x => x.LastName is not null, () =>
        {
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(NameMaxLength);
        });

        When(x => x.ZipCode is not null, () =>
        {
            RuleFor(x => x.ZipCode)
                .MaximumLength(ZipCodeMaxLength);
        });

        When(x => x.Cvv is not null, () =>
        {
            RuleFor(x => x.Cvv)
                .Length(
                    CvvMinLength,
                    CvvMaxLength
                );
        });
    }
}