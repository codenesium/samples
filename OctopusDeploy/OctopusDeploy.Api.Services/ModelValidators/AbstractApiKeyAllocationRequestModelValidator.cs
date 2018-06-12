using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiKeyAllocationRequestModelValidator: AbstractValidator<ApiKeyAllocationRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiKeyAllocationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiKeyAllocationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AllocatedRules()
                {
                        this.RuleFor(x => x.Allocated).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>66e58aa8228b9be186fc6b065f151aea</Hash>
</Codenesium>*/