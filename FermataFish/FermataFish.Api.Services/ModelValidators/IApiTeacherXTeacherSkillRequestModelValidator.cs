using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiTeacherXTeacherSkillRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherXTeacherSkillRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherXTeacherSkillRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>da790666785311b273029ff591ee3987</Hash>
</Codenesium>*/