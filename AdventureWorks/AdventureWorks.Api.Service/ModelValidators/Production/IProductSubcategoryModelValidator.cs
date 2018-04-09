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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>b2fce7ff9cf00d3e3120ebb3169d1ff5</Hash>
</Codenesium>*/