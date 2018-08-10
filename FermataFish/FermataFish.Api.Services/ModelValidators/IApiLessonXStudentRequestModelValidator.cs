using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiLessonXStudentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bb03404afd8bb8244d25fa70802b964a</Hash>
</Codenesium>*/