using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventStatuServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStatuServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatuServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>23ee61c23af1f1df537b78ab2a5cc9a6</Hash>
</Codenesium>*/