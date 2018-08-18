using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiLessonStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ce0229d73318c01ae39e3129736f0034</Hash>
</Codenesium>*/