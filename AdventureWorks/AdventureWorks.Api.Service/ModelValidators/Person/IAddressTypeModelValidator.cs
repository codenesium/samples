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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>451b417631cc1875d54e795b9c5932ca</Hash>
</Codenesium>*/