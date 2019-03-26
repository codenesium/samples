using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventTeacherServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventTeacherServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f8f7dd2cac0e7cc08585c850adb8d1b5</Hash>
</Codenesium>*/