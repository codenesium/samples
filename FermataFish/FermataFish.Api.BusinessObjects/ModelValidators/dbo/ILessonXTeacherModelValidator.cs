using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonXTeacherModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1617414d507bb201c2f737f41a223048</Hash>
</Codenesium>*/