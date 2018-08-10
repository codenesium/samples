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
    <Hash>80933a357af682f309f5c044ee16d729</Hash>
</Codenesium>*/