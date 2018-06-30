using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiKeyAllocationRequestModelValidator : AbstractApiKeyAllocationRequestModelValidator, IApiKeyAllocationRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>f1058c41925b774124d000af33361ba8</Hash>
</Codenesium>*/