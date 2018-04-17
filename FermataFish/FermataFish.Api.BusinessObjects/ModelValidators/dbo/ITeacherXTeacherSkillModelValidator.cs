using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ITeacherXTeacherSkillModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(TeacherXTeacherSkillModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, TeacherXTeacherSkillModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>45381a617dd2eee689fd69c9c068f461</Hash>
</Codenesium>*/