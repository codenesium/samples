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

                IKeyAllocationRepository keyAllocationRepository;

                public AbstractApiKeyAllocationRequestModelValidator(IKeyAllocationRepository keyAllocationRepository)
                {
                        this.keyAllocationRepository = keyAllocationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiKeyAllocationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AllocatedRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>250b9502550b83fbfe8456c36073f682</Hash>
</Codenesium>*/