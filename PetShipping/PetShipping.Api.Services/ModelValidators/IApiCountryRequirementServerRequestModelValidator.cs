using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCountryRequirementServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRequirementServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequirementServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6f4a31262e449792d7af02c04523fcdf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/