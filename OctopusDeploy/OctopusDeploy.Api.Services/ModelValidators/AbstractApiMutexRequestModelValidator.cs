using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiMutexRequestModelValidator : AbstractValidator<ApiMutexRequestModel>
        {
                private string existingRecordId;

                private IMutexRepository mutexRepository;

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
                }
        }
}

/*<Codenesium>
    <Hash>b01b4a30c43222d0ebeaffe962636b73</Hash>
</Codenesium>*/