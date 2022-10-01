using FluentValidation;
using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Application.Validators.Helpers;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;

namespace InventoryApp.Api.Application.Validators.TiposDocumentos
{
    public class CreateTiposDocumentoDtoValidator : AbstractValidator<CreateTiposDocumentoDto>
    {
        private readonly g5FtGnkAVWContext context;

        public CreateTiposDocumentoDtoValidator(g5FtGnkAVWContext context)
        {
            this.context = context;
            ValidationTiposDocumentosDB validationTiposDocumentos = new(this.context);

            #region Descripcion
            RuleFor(x => x.Descripcion)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .MaximumLength(60).WithMessage(ValidationErrorMessage.Max60)
               .Must(c =>
               {
                   return validationTiposDocumentos.IsUniqueDescripcion(c);
               })
               .WithMessage(ValidationErrorMessage.SiExiste);
            #endregion

            #region CreadoPor
            RuleFor(x => x.CreadoPor)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio);
            #endregion

        }
    }
}
