
using eCommerce.Core.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is required");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");
    }
}

