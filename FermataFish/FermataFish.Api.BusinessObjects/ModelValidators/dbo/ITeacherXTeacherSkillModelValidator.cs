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
    <Hash>8148f20700b65ce36bc6967f2981e625</Hash>
</Codenesium>*/