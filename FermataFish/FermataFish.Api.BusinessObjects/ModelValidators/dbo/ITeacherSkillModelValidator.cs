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
    <Hash>70f753bcedb3638817c829786573c0d9</Hash>
</Codenesium>*/