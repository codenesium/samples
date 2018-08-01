using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiLessonXTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c439aa0bebdaf1376c7149b5d18baa01</Hash>
</Codenesium>*/