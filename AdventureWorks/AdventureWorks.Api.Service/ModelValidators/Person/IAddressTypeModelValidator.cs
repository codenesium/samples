using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IAddressTypeModelValidator
	{
		ValidationResult Validate(AddressTypeModel entity);

		Task<ValidationResult> ValidateAsync(AddressTypeModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>c1677cad95d2554703f94acd84e21401</Hash>
</Codenesium>*/