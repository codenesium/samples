using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiTagSetRequestModelValidator: AbstractApiTagSetRequestModelValidator, IApiTagSetRequestModelValidator
        {
                public ApiTagSetRequestModelValidator(ITagSetRepository tagSetRepository)
                        : base(tagSetRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTagSetRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        this.SortOrderRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiTagSetRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        this.SortOrderRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>49f7c31bb08fa36412c2f5b3a0f3bee7</Hash>
</Codenesium>*/