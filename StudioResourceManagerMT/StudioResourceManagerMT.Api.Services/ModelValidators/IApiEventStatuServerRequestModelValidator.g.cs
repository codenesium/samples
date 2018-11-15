using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventStatuServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventStatuServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatuServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fb48b77a05092a682a6c14f189e07329</Hash>
</Codenesium>*/