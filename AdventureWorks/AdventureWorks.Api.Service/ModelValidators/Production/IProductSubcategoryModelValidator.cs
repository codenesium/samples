using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductSubcategoryModelValidator
	{
		ValidationResult Validate(ProductSubcategoryModel entity);

		Task<ValidationResult> ValidateAsync(ProductSubcategoryModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>bb41e6a05206eb8eecbf8940effaaf51</Hash>
</Codenesium>*/