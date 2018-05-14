using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonXStudentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8404d0420921fac691cb9efab0684601</Hash>
</Codenesium>*/