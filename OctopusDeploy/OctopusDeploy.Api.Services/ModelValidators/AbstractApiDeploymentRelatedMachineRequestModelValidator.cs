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
        public abstract class AbstractApiDeploymentRelatedMachineRequestModelValidator: AbstractValidator<ApiDeploymentRelatedMachineRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiDeploymentRelatedMachineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentRelatedMachineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IDeploymentRepository DeploymentRepository { get; set; }

                public virtual void DeploymentIdRules()
                {
                        this.RuleFor(x => x.DeploymentId).NotNull();
                        this.RuleFor(x => x.DeploymentId).MustAsync(this.BeValidDeployment).When(x => x ?.DeploymentId != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x.DeploymentId).Length(0, 50);
                }

                public virtual void MachineIdRules()
                {
                        this.RuleFor(x => x.MachineId).NotNull();
                        this.RuleFor(x => x.MachineId).Length(0, 50);
                }

                private async Task<bool> BeValidDeployment(string id,  CancellationToken cancellationToken)
                {
                        var record = await this.DeploymentRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>5b45cbf0cdb7471e55875d431092a52d</Hash>
</Codenesium>*/