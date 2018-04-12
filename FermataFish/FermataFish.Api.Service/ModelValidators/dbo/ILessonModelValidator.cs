using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ILessonModelValidator
	{
		ValidationResult Validate(LessonModel entity);

		Task<ValidationResult> ValidateAsync(LessonModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>204c566f0096b65f45780484b7e8b677</Hash>
</Codenesium>*/