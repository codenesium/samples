using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiPaymentTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>65d25f7a40606508634b8ff32631e5ea</Hash>
</Codenesium>*/