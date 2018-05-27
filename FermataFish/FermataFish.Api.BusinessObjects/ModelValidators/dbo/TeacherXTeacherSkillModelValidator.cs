using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiTeacherXTeacherSkillRequestModelValidator: AbstractApiTeacherXTeacherSkillRequestModelValidator, IApiTeacherXTeacherSkillRequestModelValidator
	{
		public ApiTeacherXTeacherSkillRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherXTeacherSkillRequestModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherXTeacherSkillRequestModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>614936df7180cf7cb817a014f5b21de6</Hash>
</Codenesium>*/