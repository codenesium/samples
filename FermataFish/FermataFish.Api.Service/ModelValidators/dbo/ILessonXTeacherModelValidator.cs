using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ILessonXTeacherModelValidator
	{
		ValidationResult Validate(LessonXTeacherModel entity);

		Task<ValidationResult> ValidateAsync(LessonXTeacherModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d0e775e4edd4c131324c26b635a305e9</Hash>
</Codenesium>*/