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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>8a0491b6985f2983754705e60e22fe0e</Hash>
</Codenesium>*/