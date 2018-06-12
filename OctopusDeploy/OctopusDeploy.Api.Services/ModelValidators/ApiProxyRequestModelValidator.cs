using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiProxyRequestModelValidator: AbstractApiProxyRequestModelValidator, IApiProxyRequestModelValidator
        {
                public ApiProxyRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProxyRequestModel model)
                {
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiProxyRequestModel model)
                {
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
    <Hash>de5c8106eecf1ca81a16eeeb5a7dd682</Hash>
</Codenesium>*/