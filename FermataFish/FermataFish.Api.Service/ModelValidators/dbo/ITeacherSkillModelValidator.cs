using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ITeacherSkillModelValidator
	{
		ValidationResult Validate(TeacherSkillModel entity);

		Task<ValidationResult> ValidateAsync(TeacherSkillModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>e703d59982f727f7dbf40777809821de</Hash>
</Codenesium>*/