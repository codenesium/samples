using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiTeacherXTeacherSkillRequestModelValidator: AbstractApiTeacherXTeacherSkillRequestModelValidator, IApiTeacherXTeacherSkillRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>58085efec3f898d98aabc670c3cd5875</Hash>
</Codenesium>*/