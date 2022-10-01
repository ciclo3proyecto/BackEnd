using FluentValidation;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Application.Validators.Helpers;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;

namespace InventoryApp.Api.Application.Validators.Usuarios
{
    public class DeleteUsuarioDtoValidator : AbstractValidator<DeleteUsuarioDto>
    {
        private readonly g5FtGnkAVWContext context;

        public DeleteUsuarioDtoValidator(g5FtGnkAVWContext context)
        {
            this.context = context;
            ValidationExistEntity validationExistEntity = new(this.context);

            #region Id
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .Must(c => { return validationExistEntity.ExistUsuario((int)c); })
                .WithMessage(ValidationErrorMessage.NoExiste);
            #endregion
        }
    }
}
