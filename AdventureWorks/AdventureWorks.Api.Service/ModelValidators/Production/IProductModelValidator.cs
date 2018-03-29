using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductModelValidator
	{
		ValidationResult Validate(ProductModel entity);

		Task<ValidationResult> ValidateAsync(ProductModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>ec08571f1806ab5f9823ae81a8fd7835</Hash>
</Codenesium>*/