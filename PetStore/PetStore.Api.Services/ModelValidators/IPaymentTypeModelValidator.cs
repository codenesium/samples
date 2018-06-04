using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.Services
{
	public interface IApiPaymentTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fbfd31198fe60409ea020b6b0ce29de7</Hash>
</Codenesium>*/