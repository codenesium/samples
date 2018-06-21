using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
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
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model)
                {
                        this.NameRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>59f8502927c99ef7f4c117cc0d0a8429</Hash>
</Codenesium>*/