using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiDestinationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6374e3f823a9d0f4e358d73d822add51</Hash>
</Codenesium>*/