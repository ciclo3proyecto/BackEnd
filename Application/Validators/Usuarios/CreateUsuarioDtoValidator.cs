using FluentValidation;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Application.Validators.Helpers;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;

namespace InventoryApp.Api.Application.Validators.Usuarios
{
    public class CreateUsuarioDtoValidator : AbstractValidator<CreateUsuarioDto>
    {
        private readonly g5FtGnkAVWContext context;
        public CreateUsuarioDtoValidator(g5FtGnkAVWContext context)
        {
            this.context = context;
            ValidationExistEntity validationExistEntity = new(this.context);
            ValidationUsuariosDB validationUsuariosDB = new(this.context);

            #region PerfilesId
            RuleFor(x => x.PerfilesId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .Must(c => { return validationExistEntity.ExistPerfil(c); })
                .WithMessage(ValidationErrorMessage.NoExiste);
            #endregion

            #region Identificacion
            RuleFor(x => x.Identificacion)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .Must(c => { return !validationUsuariosDB.ExistIdentificacion(c); })
                .WithMessage(ValidationErrorMessage.SiExiste);
            #endregion

            #region TiposdocumentosId
            RuleFor(x => x.TiposdocumentosId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .Must(c => { return validationExistEntity.ExistTipoDocumento(c); })
                .WithMessage(ValidationErrorMessage.NoExiste);
            #endregion

            #region Login
            RuleFor(x => x.Login)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .MinimumLength(2).WithMessage(ValidationErrorMessage.Min4)
                .MaximumLength(40).WithMessage(ValidationErrorMessage.Max40)
                .Must(c => { return !validationUsuariosDB.ExistLogin(c); })
                .WithMessage(ValidationErrorMessage.SiExiste);
            #endregion

            #region Password
            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithName("{Password}")
                .NotEmpty().WithName("{Password}")
                .MinimumLength(8).WithMessage(ValidationErrorMessage.Min8)
                .MaximumLength(20).WithName("{Password}")
                .Must(new ValidationPassword().IsValidPassword)
                .WithMessage(ValidationErrorMessage.InvalidPassword);
            #endregion

            #region Nombres
            RuleFor(x => x.Nombres)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .MaximumLength(100).WithMessage(ValidationErrorMessage.Max100);
            #endregion

            #region Primerapellido
            RuleFor(x => x.Primerapellido)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .MaximumLength(100).WithMessage(ValidationErrorMessage.Max100);
            #endregion

            #region Segundoapellido
            RuleFor(x => x.Segundoapellido)
               .Cascade(CascadeMode.Stop)
               .MaximumLength(100).WithMessage(ValidationErrorMessage.Max100);
            #endregion

            #region CreadoPor
            RuleFor(x => x.Creadopor)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio);
            #endregion
        }

    }
}
