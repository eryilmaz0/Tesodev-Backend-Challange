using FluentValidation;
using TesodevMicroservices.OrderService.Application.Dto;

namespace TesodevMicroservices.OrderService.Application.Validator.UpdateOrder
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id Field Can not be Null or Empty.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name Field Can not be Null or Empty.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Product ImageUrl Field Can not be Null or Empty.");
        }
    }
}