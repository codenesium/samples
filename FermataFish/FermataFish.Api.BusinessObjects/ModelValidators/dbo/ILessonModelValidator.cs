using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiLessonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4240faee43850f9c45333c62a0fbe201</Hash>
</Codenesium>*/