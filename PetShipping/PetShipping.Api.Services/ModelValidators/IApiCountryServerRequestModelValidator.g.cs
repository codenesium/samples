using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCountryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>458ab88b2c3f07496da3692793f28481</Hash>
</Codenesium>*/