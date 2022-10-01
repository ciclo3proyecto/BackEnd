using FluentValidation;
using InventoryApp.Api.Application.Dtos.Productos;
using InventoryApp.Api.Application.Validators.Helpers;
using InventoryApp.Api.Infraestructure.Constanst;
using InventoryApp.Api.Infraestructure.Contexts;

namespace InventoryApp.Api.Application.Validators.Productos
{
    public class CreateProductoDtoValidator : AbstractValidator<CreateProductoDto>
    {
        private readonly g5FtGnkAVWContext context;

        public CreateProductoDtoValidator(g5FtGnkAVWContext context)
        {
            this.context = context;
            ValidationExistEntity validationExistEntity = new(this.context);
            ValidationProductosDB validationProductosDB = new(this.context);

            #region UnidadesId
            RuleFor(x => x.UnidadesId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .Must(c => { return validationExistEntity.ExistUnidad(c); })
                .WithMessage(ValidationErrorMessage.NoExiste);
            #endregion

            #region Codigo
            RuleFor(x => x.Codigo)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .MinimumLength(4).WithMessage(ValidationErrorMessage.Min4)
                .MaximumLength(10).WithMessage(ValidationErrorMessage.Max10)
                .Must(c => { return !validationProductosDB.ExistCodigo(c); })
                .WithMessage(ValidationErrorMessage.SiExiste);
            #endregion

            #region Nombre
            RuleFor(x => x.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .MinimumLength(4).WithMessage(ValidationErrorMessage.Min4)
                .MaximumLength(50).WithMessage(ValidationErrorMessage.Max50);

            #endregion

            #region Descripcion
            RuleFor(x => x.Descripcion)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
                .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
                .MinimumLength(4).WithMessage(ValidationErrorMessage.Min4)
                .MaximumLength(200).WithMessage(ValidationErrorMessage.Max200);
                
            #endregion

            #region Precio
            RuleFor(x => x.Precio)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .ExclusiveBetween(1, 100000000).WithMessage(ValidationErrorMessage.Rango_1_100000000);
            #endregion

            #region Existencia
            RuleFor(x => x.Existencia)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio)
                .ExclusiveBetween(1, 100000000).WithMessage(ValidationErrorMessage.Rango_1_100000000);
            #endregion

            #region Creadopor
            RuleFor(x => x.Creadopor)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(ValidationErrorMessage.Obligatorio)
               .NotEmpty().WithMessage(ValidationErrorMessage.Obligatorio)
               .GreaterThan(0).WithMessage(ValidationErrorMessage.Obligatorio);
            #endregion



        }
    }
}
