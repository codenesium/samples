using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiLessonXTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3ed33df6e98768146f4dd72114abdd8b</Hash>
</Codenesium>*/