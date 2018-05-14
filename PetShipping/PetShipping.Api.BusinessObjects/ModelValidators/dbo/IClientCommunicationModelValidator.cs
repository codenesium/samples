using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiClientCommunicationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>851402472223d6fc32cc3c5fd751fbd3</Hash>
</Codenesium>*/