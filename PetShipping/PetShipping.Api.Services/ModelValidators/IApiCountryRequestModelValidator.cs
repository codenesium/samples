using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCountryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3c3302a299dce0073becd566d623ebcb</Hash>
</Codenesium>*/