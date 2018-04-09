using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductCategoryModelValidator
	{
		ValidationResult Validate(ProductCategoryModel entity);

		Task<ValidationResult> ValidateAsync(ProductCategoryModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>8359b3dc4c12fa10113c4038538f14ad</Hash>
</Codenesium>*/