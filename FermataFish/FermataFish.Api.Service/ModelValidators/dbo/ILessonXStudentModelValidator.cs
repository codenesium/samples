using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ILessonXStudentModelValidator
	{
		ValidationResult Validate(LessonXStudentModel entity);

		Task<ValidationResult> ValidateAsync(LessonXStudentModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>9c479bab4a36091cda951bb9b988494b</Hash>
</Codenesium>*/