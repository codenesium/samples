using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>eeffeccca3b0dcc3d1731355f0711c00</Hash>
</Codenesium>*/