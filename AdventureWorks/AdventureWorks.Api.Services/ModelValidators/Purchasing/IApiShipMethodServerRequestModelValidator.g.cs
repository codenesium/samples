using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShipMethodServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShipMethodServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4c7429259a703c9069c4df9f9b0a0444</Hash>
</Codenesium>*/