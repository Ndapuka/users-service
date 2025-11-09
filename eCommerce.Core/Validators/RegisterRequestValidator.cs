
using eCommerce.Core.DTO;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest> 
{ 
    public RegisterRequestValidator()
    {
    RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is required");
    RuleFor(temp => temp.Password)
        .NotEmpty().WithMessage("Password is required")
        .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
        .Matches(@"[!@#$%^&*(),.?]").WithMessage("Password must contain at least one special character (!@#$%^&*)");
    RuleFor(request => request.PersonName).NotEmpty().WithMessage("PersonName is required").Length(1, 50).WithMessage("Person Name shoulb be 1 and 50 characters ");
    RuleFor(temp => temp.Gender)
    .IsInEnum().WithMessage("Gender must be a valid value: Male, Female, or Others.");
    }
}

