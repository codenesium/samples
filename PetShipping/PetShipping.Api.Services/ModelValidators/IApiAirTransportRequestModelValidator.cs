using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiAirTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirTransportRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e480366bd821807d80ca13ce2b67fd2a</Hash>
</Codenesium>*/