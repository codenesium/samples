using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ILessonStatusModelValidator
	{
		ValidationResult Validate(LessonStatusModel entity);

		Task<ValidationResult> ValidateAsync(LessonStatusModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>464fd9038b40b05e6ff5ee0208ca3717</Hash>
</Codenesium>*/