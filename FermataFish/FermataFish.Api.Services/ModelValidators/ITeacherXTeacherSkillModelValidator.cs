using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiTeacherXTeacherSkillRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherXTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherXTeacherSkillRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5fc4b5b689f69ff241ccfe8e628c0dd9</Hash>
</Codenesium>*/