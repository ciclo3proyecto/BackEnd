using FluentValidation;
using InventoryApp.Api.Application.Dtos.TiposDocumentos;
using InventoryApp.Api.Application.Validators.Helpers;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;

namespace InventoryApp.Api.Application.Validators.TiposDocumentos
{
    public class DeleteTiposDocumentoDtoValidator : AbstractValidator<DeleteTiposDocumentoDto>
    {
        private readonly g5FtGnkAVWContext context;

        public DeleteTiposDocumentoDtoValidator(g5FtGnkAVWContext context)
        {
            this.context = context;

            ValidationExistEntity validationExistEntity = new(this.context);

            #region Id
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .Must(c => { return validationExistEntity.ExistTipoDocumento((int)c); })
                .WithMessage(ValidationErrorMessage.NoExiste);
            #endregion

            #region Eliminadopor
            RuleFor(x => x.Eliminadopor)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio);
            #endregion
        }
    }
}
