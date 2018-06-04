using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiHandlerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>96e20680ffa90ce7d36be507fbe4df60</Hash>
</Codenesium>*/