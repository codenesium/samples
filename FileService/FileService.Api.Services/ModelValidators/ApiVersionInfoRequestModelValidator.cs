using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
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
    <Hash>18f922fa5e91bf75f2f505d176c974ec</Hash>
</Codenesium>*/