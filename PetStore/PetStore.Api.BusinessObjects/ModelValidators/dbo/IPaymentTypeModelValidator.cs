using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiPaymentTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bb53b8062b93248b0dd014b2c8937382</Hash>
</Codenesium>*/