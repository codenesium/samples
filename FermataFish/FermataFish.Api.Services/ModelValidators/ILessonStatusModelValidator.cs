using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiLessonStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>30ab5c4e9b0964b4c8ebdcabe4039c60</Hash>
</Codenesium>*/