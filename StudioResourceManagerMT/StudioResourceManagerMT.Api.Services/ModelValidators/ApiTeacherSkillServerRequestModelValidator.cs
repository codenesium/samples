using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiTeacherSkillServerRequestModelValidator : AbstractApiTeacherSkillServerRequestModelValidator, IApiTeacherSkillServerRequestModelValidator
	{
		public ApiTeacherSkillServerRequestModelValidator(ITeacherSkillRepository teacherSkillRepository)
			: base(teacherSkillRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>120a46b83de1c6296c177070176ef676</Hash>
</Codenesium>*/