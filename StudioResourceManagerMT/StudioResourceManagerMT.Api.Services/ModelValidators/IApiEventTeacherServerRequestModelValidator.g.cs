using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiEventTeacherServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventTeacherServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8378aab782ce6ae17594b4c42a2942e5</Hash>
</Codenesium>*/