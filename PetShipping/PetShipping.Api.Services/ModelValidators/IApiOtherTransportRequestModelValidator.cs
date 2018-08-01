using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiOtherTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f9161455497d6b12f883c2238c024e95</Hash>
</Codenesium>*/