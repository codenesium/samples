using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiTeacherTeacherSkillServerRequestModelValidator : AbstractApiTeacherTeacherSkillServerRequestModelValidator, IApiTeacherTeacherSkillServerRequestModelValidator
	{
		public ApiTeacherTeacherSkillServerRequestModelValidator(ITeacherTeacherSkillRepository teacherTeacherSkillRepository)
			: base(teacherTeacherSkillRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherTeacherSkillServerRequestModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherTeacherSkillServerRequestModel model)
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6e792c6f8ea1129e655c46a540544fbd</Hash>
</Codenesium>*/