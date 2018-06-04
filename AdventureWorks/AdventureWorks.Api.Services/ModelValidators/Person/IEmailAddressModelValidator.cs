using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiEmailAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>091a23b09080a369cd289c5429c06673</Hash>
</Codenesium>*/