using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiTeacherSkillRequestModelValidator: AbstractApiTeacherSkillRequestModelValidator, IApiTeacherSkillRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>a9afedd3e5d2c4ab936e634a579e24ed</Hash>
</Codenesium>*/