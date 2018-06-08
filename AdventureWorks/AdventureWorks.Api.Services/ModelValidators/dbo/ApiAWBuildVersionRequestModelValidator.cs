using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiAWBuildVersionRequestModelValidator: AbstractApiAWBuildVersionRequestModelValidator, IApiAWBuildVersionRequestModelValidator
        {
                public ApiAWBuildVersionRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionRequestModel model)
                {
                        this.Database_VersionRules();
                        this.ModifiedDateRules();
                        this.VersionDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionRequestModel model)
                {
                        this.Database_VersionRules();
                        this.ModifiedDateRules();
                        this.VersionDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>76e64e6efd3e69208503bf0f7004e35f</Hash>
</Codenesium>*/