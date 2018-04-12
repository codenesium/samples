using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface ITeacherModelValidator
	{
		ValidationResult Validate(TeacherModel entity);

		Task<ValidationResult> ValidateAsync(TeacherModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>16bf188552ddcd7bc498a695315e597d</Hash>
</Codenesium>*/