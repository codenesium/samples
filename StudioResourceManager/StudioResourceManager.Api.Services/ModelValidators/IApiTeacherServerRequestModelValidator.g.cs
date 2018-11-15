using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiTeacherServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>92015e2273193b6865c70eceba07a2c7</Hash>
</Codenesium>*/