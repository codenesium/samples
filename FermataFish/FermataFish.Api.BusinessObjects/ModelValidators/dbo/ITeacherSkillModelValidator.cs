using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ITeacherSkillModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(TeacherSkillModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, TeacherSkillModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6f4e915bce43f48cb4afe802e287e71b</Hash>
</Codenesium>*/