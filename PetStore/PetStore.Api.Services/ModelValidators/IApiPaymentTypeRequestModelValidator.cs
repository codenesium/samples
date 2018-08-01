using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>e3ffdda962d759057ca30fd00ef447c9</Hash>
</Codenesium>*/