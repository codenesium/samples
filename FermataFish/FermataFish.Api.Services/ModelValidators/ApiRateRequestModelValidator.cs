using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiRateRequestModelValidator: AbstractApiRateRequestModelValidator, IApiRateRequestModelValidator
        {
                public ApiRateRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiRateRequestModel model)
                {
                        this.AmountPerMinuteRules();
                        this.TeacherIdRules();
                        this.TeacherSkillIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateRequestModel model)
                {
                        this.AmountPerMinuteRules();
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
    <Hash>baa7a6d6783da83edf9849157637db22</Hash>
</Codenesium>*/