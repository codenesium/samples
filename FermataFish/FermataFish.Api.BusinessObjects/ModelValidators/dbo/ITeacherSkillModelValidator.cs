using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiTeacherSkillRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c4df6f064f39d44b61157f251ad29add</Hash>
</Codenesium>*/