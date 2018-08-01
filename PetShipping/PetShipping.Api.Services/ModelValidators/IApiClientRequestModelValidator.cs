using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiClientRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c5f65e64bfac349d782616244b00db9d</Hash>
</Codenesium>*/