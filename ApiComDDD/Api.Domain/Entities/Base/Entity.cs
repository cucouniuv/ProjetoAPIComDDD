using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public abstract class Entity
    {
		[NotMapped]
		public bool Valid { get; private set; }
		[NotMapped]
		public bool Invalid => !Valid;
		[NotMapped]
		public ValidationResult ValidationResult { get; private set; }

		public bool Validar<TModel>(TModel model, AbstractValidator<TModel> validator)
		{
			ValidationResult = validator.Validate(model);
			return Valid = ValidationResult.IsValid;
		}
	}
}
