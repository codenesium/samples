using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiEventRequestModelValidator: AbstractApiEventRequestModelValidator, IApiEventRequestModelValidator
        {
                public ApiEventRequestModelValidator(IEventRepository eventRepository)
                        : base(eventRepository)
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
    <Hash>418e88f14a9f3c3a03d1384eb069b7f1</Hash>
</Codenesium>*/