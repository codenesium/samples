using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IAddressModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(AddressModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, AddressModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>03cbfbdad2725442251690f32d7e8dfd</Hash>
</Codenesium>*/