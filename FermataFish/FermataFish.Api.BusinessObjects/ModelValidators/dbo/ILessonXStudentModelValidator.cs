using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonXStudentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9bf63bf006de77d3274f6809d03cbac8</Hash>
</Codenesium>*/