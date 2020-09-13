using FluentValidation;

namespace Api.Domain.Entities.Validation
{
	public class ClienteValidador : AbstractValidator<Cliente>
	{
		public ClienteValidador()
		{
			RuleFor(a => a.Nome)
				.NotEmpty()
				.WithMessage("Nome do cliente inválido");
		}
	}
}
