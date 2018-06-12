using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiActionTemplateVersionRequestModelValidator: AbstractApiActionTemplateVersionRequestModelValidator, IApiActionTemplateVersionRequestModelValidator
        {
                public ApiActionTemplateVersionRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateVersionRequestModel model)
                {
                        this.ActionTypeRules();
                        this.JSONRules();
                        this.LatestActionTemplateIdRules();
                        this.NameRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateVersionRequestModel model)
                {
                        this.ActionTypeRules();
                        this.JSONRules();
                        this.LatestActionTemplateIdRules();
                        this.NameRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>747bc36a9791d43c805226d81666f838</Hash>
</Codenesium>*/