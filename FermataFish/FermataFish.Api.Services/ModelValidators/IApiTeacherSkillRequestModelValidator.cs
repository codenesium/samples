using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiTeacherSkillRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c648ef09fefe57bab0d867a8fb678b33</Hash>
</Codenesium>*/