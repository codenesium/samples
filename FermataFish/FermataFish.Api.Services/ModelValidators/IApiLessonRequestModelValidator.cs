using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiLessonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d317bb59b876947691c40bc5614e410c</Hash>
</Codenesium>*/