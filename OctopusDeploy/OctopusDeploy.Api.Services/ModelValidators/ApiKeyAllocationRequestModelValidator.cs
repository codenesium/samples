using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiKeyAllocationRequestModelValidator: AbstractApiKeyAllocationRequestModelValidator, IApiKeyAllocationRequestModelValidator
        {
                public ApiKeyAllocationRequestModelValidator(IKeyAllocationRepository keyAllocationRepository)
                        : base(keyAllocationRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiKeyAllocationRequestModel model)
                {
                        this.AllocatedRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiKeyAllocationRequestModel model)
                {
                        this.AllocatedRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d9a8517a1518766f48128cb189d987a1</Hash>
</Codenesium>*/