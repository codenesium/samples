using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ITeacherSkillModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(TeacherSkillModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, TeacherSkillModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ed7e8c80080777010170e7c7b8e9f5d4</Hash>
</Codenesium>*/