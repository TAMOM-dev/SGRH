using System;
using System.Linq.Expressions;
using FluentValidation;

namespace SGRH.Application.Base.Validators;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    protected void ValidateId(Expression<Func<T, int>> idSelector)
    {
        RuleFor(idSelector)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0");
    }

    protected void ValidateString(Expression<Func<T, string>> selector, string fieldName, int maxLength = 100)
    {
        RuleFor(selector)
            .NotEmpty().WithMessage($"{fieldName} is required.")
            .MaximumLength(maxLength).WithMessage($"{fieldName} must not exceed {maxLength} characters.");
    }

    protected void ValidatePositiveNumber(Expression<Func<T, decimal>> selector, string fieldName)
    {
        RuleFor(selector)
            .GreaterThan(0).WithMessage($"{fieldName} must be greater than 0.");
    }
}
