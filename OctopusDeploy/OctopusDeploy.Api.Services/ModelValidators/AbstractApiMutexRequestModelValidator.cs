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
        public abstract class AbstractApiMutexRequestModelValidator: AbstractValidator<ApiMutexRequestModel>
        {
                private string existingRecordId;

                IMutexRepository mutexRepository;

                public AbstractApiMutexRequestModelValidator(IMutexRepository mutexRepository)
                {
                        this.mutexRepository = mutexRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiMutexRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>70bd41c2d9895826ec20eaa937e7f370</Hash>
</Codenesium>*/