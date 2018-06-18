using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiPipelineStatusRequestModelValidator: AbstractValidator<ApiPipelineStatusRequestModel>
        {
                private int existingRecordId;

                IPipelineStatusRepository pipelineStatusRepository;

                public AbstractApiPipelineStatusRequestModelValidator(IPipelineStatusRepository pipelineStatusRepository)
                {
                        this.pipelineStatusRepository = pipelineStatusRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineStatusRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>5dfd37ad98dad740388b9f18dd9db00d</Hash>
</Codenesium>*/