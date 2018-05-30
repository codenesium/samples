using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiClientCommunicationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2158d85196f63789035ff447d77c583e</Hash>
</Codenesium>*/