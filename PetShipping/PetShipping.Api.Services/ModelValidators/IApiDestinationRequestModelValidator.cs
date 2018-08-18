using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiDestinationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8ddf3a01a7f0ac6ff638e45d453cd63f</Hash>
</Codenesium>*/