using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonXTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>abf5e2d3bcb960850922036877ab1d5a</Hash>
</Codenesium>*/