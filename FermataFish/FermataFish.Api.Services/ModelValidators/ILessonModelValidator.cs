using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
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
    <Hash>a85c05239d95f86f7aacd150aabe682d</Hash>
</Codenesium>*/