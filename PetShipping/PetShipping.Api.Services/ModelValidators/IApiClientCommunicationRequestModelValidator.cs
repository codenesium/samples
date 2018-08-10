using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiClientCommunicationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f6b982748bafc58f73950c8b07128dc5</Hash>
</Codenesium>*/