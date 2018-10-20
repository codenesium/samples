using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiTeacherTeacherSkillRequestModelValidator : AbstractApiTeacherTeacherSkillRequestModelValidator, IApiTeacherTeacherSkillRequestModelValidator
	{
		public ApiTeacherTeacherSkillRequestModelValidator(ITeacherTeacherSkillRepository teacherTeacherSkillRepository)
			: base(teacherTeacherSkillRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherTeacherSkillRequestModel model)
		{
			this.TeacherSkillIdRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherTeacherSkillRequestModel model)
		{
			this.TeacherSkillIdRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f4a910efb8634a30bd2267107dded6ca</Hash>
</Codenesium>*/