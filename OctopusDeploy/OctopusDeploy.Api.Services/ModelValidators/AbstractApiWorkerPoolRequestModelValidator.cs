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
        public abstract class AbstractApiWorkerPoolRequestModelValidator: AbstractValidator<ApiWorkerPoolRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiWorkerPoolRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiWorkerPoolRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IWorkerPoolRepository WorkerPoolRepository { get; set; }
                public virtual void IsDefaultRules()
                {
                        this.RuleFor(x => x.IsDefault).NotNull();
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiWorkerPoolRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void SortOrderRules()
                {
                        this.RuleFor(x => x.SortOrder).NotNull();
                }

                private async Task<bool> BeUniqueGetName(ApiWorkerPoolRequestModel model,  CancellationToken cancellationToken)
                {
                        WorkerPool record = await this.WorkerPoolRepository.GetName(model.Name);

                        if (record == null || record.Id == this.existingRecordId)
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
    <Hash>e3186303a5fc85529be80f4ea94d29bd</Hash>
</Codenesium>*/