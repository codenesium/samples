using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiCommunityActionTemplateRequestModelValidator: AbstractApiCommunityActionTemplateRequestModelValidator, IApiCommunityActionTemplateRequestModelValidator
        {
                public ApiCommunityActionTemplateRequestModelValidator(ICommunityActionTemplateRepository communityActionTemplateRepository)
                        : base(communityActionTemplateRepository)
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
    <Hash>60901fa13b8b703fa941fb7dfe05c88a</Hash>
</Codenesium>*/