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
        public abstract class AbstractApiWorkerRequestModelValidator: AbstractValidator<ApiWorkerRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiWorkerRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiWorkerRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IWorkerRepository WorkerRepository { get; set; }
                public virtual void CommunicationStyleRules()
                {
                        this.RuleFor(x => x.CommunicationStyle).NotNull();
                        this.RuleFor(x => x.CommunicationStyle).Length(0, 50);
                }

                public virtual void FingerprintRules()
                {
                        this.RuleFor(x => x.Fingerprint).Length(0, 50);
                }

                public virtual void IsDisabledRules()
                {
                        this.RuleFor(x => x.IsDisabled).NotNull();
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void MachinePolicyIdRules()
                {
                        this.RuleFor(x => x.MachinePolicyId).NotNull();
                        this.RuleFor(x => x.MachinePolicyId).Length(0, 50);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiWorkerRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                }

                public virtual void ThumbprintRules()
                {
                        this.RuleFor(x => x.Thumbprint).Length(0, 50);
                }

                public virtual void WorkerPoolIdsRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiWorkerRequestModel model,  CancellationToken cancellationToken)
                {
                        Worker record = await this.WorkerRepository.GetName(model.Name);

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
    <Hash>c61aae5bc59b2dc65cb10818fadf4145</Hash>
</Codenesium>*/