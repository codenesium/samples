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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>4ef338103acad505f665b5e990bba4a0</Hash>
</Codenesium>*/