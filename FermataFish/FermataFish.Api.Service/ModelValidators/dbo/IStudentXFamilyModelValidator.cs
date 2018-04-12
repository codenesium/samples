using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface IStudentXFamilyModelValidator
	{
		ValidationResult Validate(StudentXFamilyModel entity);

		Task<ValidationResult> ValidateAsync(StudentXFamilyModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d677649d7759216f36252615bd395143</Hash>
</Codenesium>*/