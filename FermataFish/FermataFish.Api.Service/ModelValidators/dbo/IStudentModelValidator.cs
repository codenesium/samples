using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface IStudentModelValidator
	{
		ValidationResult Validate(StudentModel entity);

		Task<ValidationResult> ValidateAsync(StudentModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>b84722efefdfad110d6c49ced83232c5</Hash>
</Codenesium>*/