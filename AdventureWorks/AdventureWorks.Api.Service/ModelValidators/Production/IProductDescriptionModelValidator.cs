using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductDescriptionModelValidator
	{
		ValidationResult Validate(ProductDescriptionModel entity);

		Task<ValidationResult> ValidateAsync(ProductDescriptionModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>cd07b92d8a4b5750e7b1e134af2eb861</Hash>
</Codenesium>*/