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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>1229487870526a1008fec3b2bc713151</Hash>
</Codenesium>*/