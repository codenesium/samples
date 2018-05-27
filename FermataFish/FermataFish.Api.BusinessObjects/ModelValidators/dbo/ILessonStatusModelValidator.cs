using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3b7ff2475c0ddbaff61ae76d2c80f88d</Hash>
</Codenesium>*/