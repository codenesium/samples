using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiEventTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventTeacherRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bf59efe1755e7ef21bcbed6d98fdf180</Hash>
</Codenesium>*/