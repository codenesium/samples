using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonXTeacherModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LessonXTeacherModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LessonXTeacherModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>14996664db788dbe5091e0cef7ba490c</Hash>
</Codenesium>*/