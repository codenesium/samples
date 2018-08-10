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
    <Hash>2945274cfdeb383470c714be3a91ad4a</Hash>
</Codenesium>*/