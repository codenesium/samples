using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiLessonStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>08a1d45ce05dac32b50bd886703ee51e</Hash>
</Codenesium>*/