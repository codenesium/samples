using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
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
    <Hash>b62ae558d7940b801ccc5c8b345f7ae9</Hash>
</Codenesium>*/