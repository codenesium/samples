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
    <Hash>e637548dd802b72214389214d5fdf2e4</Hash>
</Codenesium>*/