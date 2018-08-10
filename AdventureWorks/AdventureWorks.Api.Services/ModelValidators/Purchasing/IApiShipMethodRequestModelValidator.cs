using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShipMethodRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>74b06a74540e586717d98f9eb70cc87f</Hash>
</Codenesium>*/