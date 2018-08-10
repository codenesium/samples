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
    <Hash>efa10dc2b0f7e498195a33d93c9c14c0</Hash>
</Codenesium>*/