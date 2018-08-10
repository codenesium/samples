using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiOtherTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>04e59e9b1053b512ca03ced017ae35d9</Hash>
</Codenesium>*/