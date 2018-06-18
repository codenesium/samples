using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiActionTemplateRequestModelValidator: AbstractApiActionTemplateRequestModelValidator, IApiActionTemplateRequestModelValidator
        {
                public ApiActionTemplateRequestModelValidator(IActionTemplateRepository actionTemplateRepository)
                        : base(actionTemplateRepository)
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
    <Hash>a8ad78017b7f81a238953ba8c85a3597</Hash>
</Codenesium>*/