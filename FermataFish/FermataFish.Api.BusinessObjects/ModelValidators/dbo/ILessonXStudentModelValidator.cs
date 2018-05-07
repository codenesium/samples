using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface ILessonXStudentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LessonXStudentModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, LessonXStudentModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>07e85f69e4500262f8f71c2d1ae46e8c</Hash>
</Codenesium>*/