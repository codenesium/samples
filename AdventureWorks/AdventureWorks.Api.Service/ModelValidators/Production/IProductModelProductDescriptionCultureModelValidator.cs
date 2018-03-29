using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductModelProductDescriptionCultureModelValidator
	{
		ValidationResult Validate(ProductModelProductDescriptionCultureModel entity);

		Task<ValidationResult> ValidateAsync(ProductModelProductDescriptionCultureModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>0dc2c5993233be970a92dbf7ddeb2ce9</Hash>
</Codenesium>*/