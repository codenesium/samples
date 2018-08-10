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
    <Hash>da4a0b0b28d64af01788e579905fd3d6</Hash>
</Codenesium>*/