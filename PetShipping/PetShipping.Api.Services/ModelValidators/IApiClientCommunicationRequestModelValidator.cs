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
    <Hash>c13a2f594f1417f3113ebe17a1fbb573</Hash>
</Codenesium>*/