using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IVendorModelValidator
	{
		ValidationResult Validate(VendorModel entity);

		Task<ValidationResult> ValidateAsync(VendorModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>847bc811431a4d0e8ffd95085197baa2</Hash>
</Codenesium>*/