using FluentValidation;
using TesodevMicroservices.OrderService.Application.Dto;

namespace TesodevMicroservices.OrderService.Application.Validator
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id Field Can not be Null or Empty.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name Field Can not be Null or Empty.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Product ImageUrl Field Can not be Null or Empty.");
        }
    }
}