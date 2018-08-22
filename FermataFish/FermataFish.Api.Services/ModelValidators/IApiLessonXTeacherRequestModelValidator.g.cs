using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiLessonXTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2947d4523b3028e672c38f1bde0a152d</Hash>
</Codenesium>*/