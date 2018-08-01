using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>a2542f5b58cd5f52b50f45524f115441</Hash>
</Codenesium>*/