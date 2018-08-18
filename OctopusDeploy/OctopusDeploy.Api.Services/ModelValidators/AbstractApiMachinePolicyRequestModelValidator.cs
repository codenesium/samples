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
	public abstract class AbstractApiMachinePolicyRequestModelValidator : AbstractValidator<ApiMachinePolicyRequestModel>
	{
		private string existingRecordId;

		private IMachinePolicyRepository machinePolicyRepository;

		public AbstractApiMachinePolicyRequestModelValidator(IMachinePolicyRepository machinePolicyRepository)
		{
			this.machinePolicyRepository = machinePolicyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachinePolicyRequestModel model, string id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiMachinePolicyRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		private async Task<bool> BeUniqueByName(ApiMachinePolicyRequestModel model,  CancellationToken cancellationToken)
		{
			MachinePolicy record = await this.machinePolicyRepository.ByName(model.Name);

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
    <Hash>f0bf1f121e9187f3a9d43adc8520ddf7</Hash>
</Codenesium>*/