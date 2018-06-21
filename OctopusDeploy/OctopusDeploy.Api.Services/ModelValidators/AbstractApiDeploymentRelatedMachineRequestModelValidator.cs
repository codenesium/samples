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
        public abstract class AbstractApiDeploymentRelatedMachineRequestModelValidator : AbstractValidator<ApiDeploymentRelatedMachineRequestModel>
        {
                private int existingRecordId;

                private IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository;

                public AbstractApiDeploymentRelatedMachineRequestModelValidator(IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository)
                {
                        this.deploymentRelatedMachineRepository = deploymentRelatedMachineRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentRelatedMachineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DeploymentIdRules()
                {
                        this.RuleFor(x => x.DeploymentId).NotNull();
                        this.RuleFor(x => x.DeploymentId).MustAsync(this.BeValidDeployment).When(x => x?.DeploymentId != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x.DeploymentId).Length(0, 50);
                }

                public virtual void MachineIdRules()
                {
                        this.RuleFor(x => x.MachineId).NotNull();
                        this.RuleFor(x => x.MachineId).Length(0, 50);
                }

                private async Task<bool> BeValidDeployment(string id,  CancellationToken cancellationToken)
                {
                        var record = await this.deploymentRelatedMachineRepository.GetDeployment(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>687ca4036da3c4a79eb392a1f5a16679</Hash>
</Codenesium>*/