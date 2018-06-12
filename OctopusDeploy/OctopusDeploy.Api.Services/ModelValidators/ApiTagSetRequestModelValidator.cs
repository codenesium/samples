using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiTagSetRequestModelValidator: AbstractApiTagSetRequestModelValidator, IApiTagSetRequestModelValidator
        {
                public ApiTagSetRequestModelValidator()
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
    <Hash>94caaa70e6d3dfc02102af30ef195d71</Hash>
</Codenesium>*/