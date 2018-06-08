using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiVersionInfoRequestModelValidator: AbstractApiVersionInfoRequestModelValidator, IApiVersionInfoRequestModelValidator
        {
                public ApiVersionInfoRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model)
                {
                        this.AppliedOnRules();
                        this.DescriptionRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model)
                {
                        this.AppliedOnRules();
                        this.DescriptionRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(long id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>8dd0e8b652f20406f5fbd48a5ccad81a</Hash>
</Codenesium>*/