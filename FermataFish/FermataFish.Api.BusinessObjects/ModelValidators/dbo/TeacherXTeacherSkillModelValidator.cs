using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiTeacherXTeacherSkillModelValidator: AbstractApiTeacherXTeacherSkillModelValidator, IApiTeacherXTeacherSkillModelValidator
	{
		public ApiTeacherXTeacherSkillModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherXTeacherSkillModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherXTeacherSkillModel model)
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
    <Hash>54e7a819f55d13e09f0d413a9f270ab4</Hash>
</Codenesium>*/