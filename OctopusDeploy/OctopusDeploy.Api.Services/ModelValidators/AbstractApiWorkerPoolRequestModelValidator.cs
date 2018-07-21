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
        public abstract class AbstractApiWorkerPoolRequestModelValidator : AbstractValidator<ApiWorkerPoolRequestModel>
        {
                private string existingRecordId;

                private IWorkerPoolRepository workerPoolRepository;

                public AbstractApiWorkerPoolRequestModelValidator(IWorkerPoolRepository workerPoolRepository)
                {
                        this.workerPoolRepository = workerPoolRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiWorkerPoolRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IsDefaultRules()
                {
                }

                public virtual void JSONRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiWorkerPoolRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void SortOrderRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiWorkerPoolRequestModel model,  CancellationToken cancellationToken)
                {
                        WorkerPool record = await this.workerPoolRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>7a59e7f445508ff3118765a719a5098f</Hash>
</Codenesium>*/