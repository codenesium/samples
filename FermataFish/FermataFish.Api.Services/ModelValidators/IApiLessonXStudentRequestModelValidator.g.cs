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
    <Hash>282704c2d8d4fa2f0965d6c70b68018b</Hash>
</Codenesium>*/