using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiCommunityActionTemplateRequestModelValidator: AbstractApiCommunityActionTemplateRequestModelValidator, IApiCommunityActionTemplateRequestModelValidator
        {
                public ApiCommunityActionTemplateRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCommunityActionTemplateRequestModel model)
                {
                        this.ExternalIdRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCommunityActionTemplateRequestModel model)
                {
                        this.ExternalIdRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>df3438bf77b8ed1f6b3f1e0ea794721b</Hash>
</Codenesium>*/