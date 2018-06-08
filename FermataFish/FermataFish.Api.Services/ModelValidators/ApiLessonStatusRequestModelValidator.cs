using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiLessonStatusRequestModelValidator: AbstractApiLessonStatusRequestModelValidator, IApiLessonStatusRequestModelValidator
        {
                public ApiLessonStatusRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model)
                {
                        this.NameRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model)
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
    <Hash>5a14a40ff37c22367ade465e115985d3</Hash>
</Codenesium>*/