using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiTeacherSkillRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>760d0985424c5c13ad8f923a901a09ac</Hash>
</Codenesium>*/