using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiTeacherXTeacherSkillRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherXTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherXTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3e5ee4aa252ae5359de57262a7cce43a</Hash>
</Codenesium>*/