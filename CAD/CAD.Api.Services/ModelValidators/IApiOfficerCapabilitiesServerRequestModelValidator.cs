using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerCapabilitiesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOfficerCapabilitiesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerCapabilitiesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dbb537f74809488261430917a134c44a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/