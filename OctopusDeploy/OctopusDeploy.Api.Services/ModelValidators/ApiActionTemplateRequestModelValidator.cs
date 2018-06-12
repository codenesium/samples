using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiActionTemplateRequestModelValidator: AbstractApiActionTemplateRequestModelValidator, IApiActionTemplateRequestModelValidator
        {
                public ApiActionTemplateRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateRequestModel model)
                {
                        this.ActionTypeRules();
                        this.CommunityActionTemplateIdRules();
                        this.JSONRules();
                        this.NameRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateRequestModel model)
                {
                        this.ActionTypeRules();
                        this.CommunityActionTemplateIdRules();
                        this.JSONRules();
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
    <Hash>3ba8d1051f665d9a265e20a3649af46a</Hash>
</Codenesium>*/