using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiEmailAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cddb0eb607413419b4c2c8e016676e78</Hash>
</Codenesium>*/