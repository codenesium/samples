using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiRateRequestModelValidator: AbstractApiRateRequestModelValidator, IApiRateRequestModelValidator
        {
                public ApiRateRequestModelValidator(IRateRepository rateRepository)
                        : base(rateRepository)
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
    <Hash>563b1949f9d651029ba38eeddb13b473</Hash>
</Codenesium>*/