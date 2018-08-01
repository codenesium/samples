using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiLessonXStudentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7c81065b171975e56009e804fd40079c</Hash>
</Codenesium>*/