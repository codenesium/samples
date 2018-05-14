using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiTeacherXTeacherSkillModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherXTeacherSkillModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherXTeacherSkillModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0fca0520311f3bbd491024089c8980a7</Hash>
</Codenesium>*/