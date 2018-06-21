using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiCommunityActionTemplateRequestModelValidator : AbstractApiCommunityActionTemplateRequestModelValidator, IApiCommunityActionTemplateRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c769017cb1fd01a2e3bb379725ce8582</Hash>
</Codenesium>*/