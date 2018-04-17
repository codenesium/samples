using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonXStudentModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LessonXStudentModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LessonXStudentModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6c1aee66acf98446dd74c0a9bf3105d9</Hash>
</Codenesium>*/