using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiEventRequestModelValidator: AbstractApiEventRequestModelValidator, IApiEventRequestModelValidator
        {
                public ApiEventRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model)
                {
                        this.AutoIdRules();
                        this.CategoryRules();
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.MessageRules();
                        this.OccurredRules();
                        this.ProjectIdRules();
                        this.RelatedDocumentIdsRules();
                        this.TenantIdRules();
                        this.UserIdRules();
                        this.UsernameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiEventRequestModel model)
                {
                        this.AutoIdRules();
                        this.CategoryRules();
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.MessageRules();
                        this.OccurredRules();
                        this.ProjectIdRules();
                        this.RelatedDocumentIdsRules();
                        this.TenantIdRules();
                        this.UserIdRules();
                        this.UsernameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>dfd2374e5e3f5ae26900156afb7c99ba</Hash>
</Codenesium>*/