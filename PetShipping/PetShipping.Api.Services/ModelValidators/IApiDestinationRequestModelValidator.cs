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
    <Hash>4c58faed733824f348abc9e84cb4a88c</Hash>
</Codenesium>*/