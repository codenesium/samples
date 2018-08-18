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
    <Hash>052ab0f41ec868b9c9a6c7424f72e1c4</Hash>
</Codenesium>*/