using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IAddressModelValidator
	{
		ValidationResult Validate(AddressModel entity);

		Task<ValidationResult> ValidateAsync(AddressModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>792ae7571f989bb1f42f49b2b3573256</Hash>
</Codenesium>*/