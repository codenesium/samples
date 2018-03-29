using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductModelModelValidator
	{
		ValidationResult Validate(ProductModelModel entity);

		Task<ValidationResult> ValidateAsync(ProductModelModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>874c97d292787402d54913dbc25cc423</Hash>
</Codenesium>*/