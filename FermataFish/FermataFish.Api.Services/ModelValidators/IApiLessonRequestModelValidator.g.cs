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
    <Hash>ba7380c85b5004a782aefed82f90d617</Hash>
</Codenesium>*/