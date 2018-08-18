using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiAirTransportRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAirTransportRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9be5cb7129e980c94fd7b7f312999c99</Hash>
</Codenesium>*/