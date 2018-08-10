using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiTeacherSkillRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24703b9755838991557d8f34721dfd19</Hash>
</Codenesium>*/