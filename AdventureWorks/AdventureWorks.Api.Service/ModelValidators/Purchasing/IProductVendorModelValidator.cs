using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductVendorModelValidator
	{
		ValidationResult Validate(ProductVendorModel entity);

		Task<ValidationResult> ValidateAsync(ProductVendorModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>027f8c608681b1fbe000a7e8bfc496a8</Hash>
</Codenesium>*/