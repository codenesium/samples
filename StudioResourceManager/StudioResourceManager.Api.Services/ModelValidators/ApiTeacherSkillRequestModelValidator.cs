using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiTeacherSkillRequestModelValidator : AbstractApiTeacherSkillRequestModelValidator, IApiTeacherSkillRequestModelValidator
	{
		public ApiTeacherSkillRequestModelValidator(ITeacherSkillRepository teacherSkillRepository)
			: base(teacherSkillRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillRequestModel model)
		{
			this.NameRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model)
		{
			this.NameRules();
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
    <Hash>11ad2f6e0260a70008088b5cf2d9c4c9</Hash>
</Codenesium>*/