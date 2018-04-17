using System;
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
    <Hash>3b9be91439a438c7ff88b7d5fa09a68a</Hash>
</Codenesium>*/