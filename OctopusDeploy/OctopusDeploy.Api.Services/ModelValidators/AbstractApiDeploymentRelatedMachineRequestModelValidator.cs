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
			this.RuleFor(x => x.DeploymentId).MustAsync(this.BeValidDeployment).When(x => x?.DeploymentId != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.DeploymentId).Length(0, 50);
		}

		public virtual void MachineIdRules()
		{
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
    <Hash>53f438bf05fc379bb790c66e677d8d12</Hash>
</Codenesium>*/