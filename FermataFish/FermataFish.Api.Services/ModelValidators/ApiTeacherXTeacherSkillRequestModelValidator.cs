using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiTeacherXTeacherSkillRequestModelValidator : AbstractApiTeacherXTeacherSkillRequestModelValidator, IApiTeacherXTeacherSkillRequestModelValidator
	{
		public ApiTeacherXTeacherSkillRequestModelValidator(ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository)
			: base(teacherXTeacherSkillRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6f59f84a68b3085306d4670233ca57e5</Hash>
</Codenesium>*/