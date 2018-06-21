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
    <Hash>abc984e22455a6c5930d16707cb282fd</Hash>
</Codenesium>*/