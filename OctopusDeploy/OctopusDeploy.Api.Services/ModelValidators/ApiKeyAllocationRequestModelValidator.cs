using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiKeyAllocationRequestModelValidator: AbstractApiKeyAllocationRequestModelValidator, IApiKeyAllocationRequestModelValidator
        {
                public ApiKeyAllocationRequestModelValidator()
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
    <Hash>9b1139e355e98d2a6586bfb8ece0c744</Hash>
</Codenesium>*/