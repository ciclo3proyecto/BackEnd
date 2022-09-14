using FluentValidation;
using InventoryApp.Api.Application.Dtos.Usuarios;
using InventoryApp.Api.Application.Validators.Helpers;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;

namespace InventoryApp.Api.Application.Validators.Usuarios
{
    public class LoginUsuarioDtoValidator : AbstractValidator<LoginUsuarioDto>
    {
        private readonly g5FtGnkAVWContext context;

        public LoginUsuarioDtoValidator(g5FtGnkAVWContext context)
        {
            this.context = context;
            ValidationUsuariosDB validationUsuariosDB = new(this.context);


            #region Login
            RuleFor(x => x.Login)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .MaximumLength(40).WithMessage(ValidationErrorMessage.Max40);
            #endregion

            #region Password
            RuleFor(x => x.Password)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .MaximumLength(40).WithMessage(ValidationErrorMessage.Max40);
            #endregion

            When(x => !string.IsNullOrEmpty(x.Login) && !string.IsNullOrEmpty(x.Login), () =>
            {
                RuleFor(x => x.Login)
                    .Cascade(CascadeMode.Stop)
                    .Must((c,a) => { return validationUsuariosDB.ExistUsuario(c.Login,c.Password); })
                    .WithMessage("Usuario y Contraseña Invalidos.");

            });


        }
    }
}
