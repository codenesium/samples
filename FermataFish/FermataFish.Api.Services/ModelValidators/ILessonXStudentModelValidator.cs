using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
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
    <Hash>a5bdd66d44b5a3719d3a81c59aac4b7e</Hash>
</Codenesium>*/