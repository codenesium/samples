using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiLessonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1007be35a69b41c851808da617cf5126</Hash>
</Codenesium>*/