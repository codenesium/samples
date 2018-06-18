using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiVersionInfoRequestModelValidator: AbstractApiVersionInfoRequestModelValidator, IApiVersionInfoRequestModelValidator
        {
                public ApiVersionInfoRequestModelValidator(IVersionInfoRepository versionInfoRepository)
                        : base(versionInfoRepository)
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
    <Hash>cc533c91d79e1bf417361f8f24277577</Hash>
</Codenesium>*/