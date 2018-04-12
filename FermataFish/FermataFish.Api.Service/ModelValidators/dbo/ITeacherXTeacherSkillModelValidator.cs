using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ITeacherXTeacherSkillModelValidator
	{
		ValidationResult Validate(TeacherXTeacherSkillModel entity);

		Task<ValidationResult> ValidateAsync(TeacherXTeacherSkillModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>230620f117eb4c878114ff3a3f57aedc</Hash>
</Codenesium>*/