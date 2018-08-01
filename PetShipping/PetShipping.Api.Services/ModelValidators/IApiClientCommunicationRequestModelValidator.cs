using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiClientCommunicationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>163bf26dfaf6e974ed8ae89241bcb59e</Hash>
</Codenesium>*/