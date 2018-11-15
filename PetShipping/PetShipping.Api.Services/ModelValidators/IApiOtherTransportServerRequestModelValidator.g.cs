using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiOtherTransportServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>94c9cc93e45e705c87a417be712df7b0</Hash>
</Codenesium>*/