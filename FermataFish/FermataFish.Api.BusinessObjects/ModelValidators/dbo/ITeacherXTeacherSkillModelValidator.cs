using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ITeacherXTeacherSkillModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(TeacherXTeacherSkillModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, TeacherXTeacherSkillModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>df66bd1b8c957e4e07a79ae8f2da8387</Hash>
</Codenesium>*/