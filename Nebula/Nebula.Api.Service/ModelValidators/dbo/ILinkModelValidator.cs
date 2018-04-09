using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface ILinkModelValidator
	{
		ValidationResult Validate(LinkModel entity);

		Task<ValidationResult> ValidateAsync(LinkModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>6ee8a7bac8b92d246294e49fbf76f9a7</Hash>
</Codenesium>*/