using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiStudioServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudioServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0d36904458193620f2b44b39afcf09a6</Hash>
</Codenesium>*/