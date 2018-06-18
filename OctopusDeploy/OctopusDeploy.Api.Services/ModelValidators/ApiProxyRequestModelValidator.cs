using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiProxyRequestModelValidator: AbstractApiProxyRequestModelValidator, IApiProxyRequestModelValidator
        {
                public ApiProxyRequestModelValidator(IProxyRepository proxyRepository)
                        : base(proxyRepository)
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
    <Hash>27eed7ddf7fdfa8b54ae553ba13aba3c</Hash>
</Codenesium>*/