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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>c3694c16b0329e5a3ddfa64dd108d373</Hash>
</Codenesium>*/