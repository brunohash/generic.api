using Application.Commands;
using FluentValidation;

namespace Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>, IValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O campo 'name' é obrigatório.")
                .MinimumLength(3).WithMessage("O campo 'name' não pode ter menos de 3 caracteres.");

            RuleFor(command => command.Description)
                .MaximumLength(200).WithMessage("O campo 'description' não pode ter mais de 200 caracteres.");
        }
    }
}

