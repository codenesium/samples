using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>928205f71b94704f53b734e66425f180</Hash>
</Codenesium>*/