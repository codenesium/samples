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
	public abstract class AbstractApiMachineRequestModelValidator : AbstractValidator<ApiMachineRequestModel>
	{
		private string existingRecordId;

		private IMachineRepository machineRepository;

		public AbstractApiMachineRequestModelValidator(IMachineRepository machineRepository)
		{
			this.machineRepository = machineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CommunicationStyleRules()
		{
			this.RuleFor(x => x.CommunicationStyle).Length(0, 50);
		}

		public virtual void EnvironmentIdsRules()
		{
		}

		public virtual void FingerprintRules()
		{
			this.RuleFor(x => x.Fingerprint).Length(0, 50);
		}

		public virtual void IsDisabledRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void MachinePolicyIdRules()
		{
			this.RuleFor(x => x.MachinePolicyId).Length(0, 50);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiMachineRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void RelatedDocumentIdsRules()
		{
		}

		public virtual void RolesRules()
		{
		}

		public virtual void TenantIdsRules()
		{
		}

		public virtual void TenantTagsRules()
		{
		}

		public virtual void ThumbprintRules()
		{
			this.RuleFor(x => x.Thumbprint).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiMachineRequestModel model,  CancellationToken cancellationToken)
		{
			Machine record = await this.machineRepository.ByName(model.Name);

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
    <Hash>be012c5f755018990a9f355bf774938e</Hash>
</Codenesium>*/