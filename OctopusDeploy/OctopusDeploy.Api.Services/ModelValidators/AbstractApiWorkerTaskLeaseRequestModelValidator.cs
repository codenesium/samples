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
        public abstract class AbstractApiWorkerTaskLeaseRequestModelValidator: AbstractValidator<ApiWorkerTaskLeaseRequestModel>
        {
                private string existingRecordId;

                IWorkerTaskLeaseRepository workerTaskLeaseRepository;

                public AbstractApiWorkerTaskLeaseRequestModelValidator(IWorkerTaskLeaseRepository workerTaskLeaseRepository)
                {
                        this.workerTaskLeaseRepository = workerTaskLeaseRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiWorkerTaskLeaseRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ExclusiveRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void TaskIdRules()
                {
                        this.RuleFor(x => x.TaskId).NotNull();
                        this.RuleFor(x => x.TaskId).Length(0, 50);
                }

                public virtual void WorkerIdRules()
                {
                        this.RuleFor(x => x.WorkerId).NotNull();
                        this.RuleFor(x => x.WorkerId).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>29b97e8851c42d9734ecfe6c5f5283bb</Hash>
</Codenesium>*/