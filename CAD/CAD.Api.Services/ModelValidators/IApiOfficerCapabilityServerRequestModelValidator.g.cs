using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerCapabilityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOfficerCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c0037dcd4c43a3aad6256dcf79d1167f</Hash>
</Codenesium>*/