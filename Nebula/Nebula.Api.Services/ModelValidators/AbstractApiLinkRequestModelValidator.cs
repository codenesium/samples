using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiLinkRequestModelValidator : AbstractValidator<ApiLinkRequestModel>
	{
		private int existingRecordId;

		private ILinkRepository linkRepository;

		public AbstractApiLinkRequestModelValidator(ILinkRepository linkRepository)
		{
			this.linkRepository = linkRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AssignedMachineIdRules()
		{
			this.RuleFor(x => x.AssignedMachineId).MustAsync(this.BeValidMachineByAssignedMachineId).When(x => x?.AssignedMachineId != null).WithMessage("Invalid reference");
		}

		public virtual void ChainIdRules()
		{
			this.RuleFor(x => x.ChainId).MustAsync(this.BeValidChainByChainId).When(x => x?.ChainId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCompletedRules()
		{
		}

		public virtual void DateStartedRules()
		{
		}

		public virtual void DynamicParameterRules()
		{
			this.RuleFor(x => x.DynamicParameter).Length(0, 2147483647);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => x?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkRequestModel.ExternalId));
		}

		public virtual void LinkStatusIdRules()
		{
			this.RuleFor(x => x.LinkStatusId).MustAsync(this.BeValidLinkStatusByLinkStatusId).When(x => x?.LinkStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrderRules()
		{
		}

		public virtual void ResponseRules()
		{
			this.RuleFor(x => x.Response).Length(0, 2147483647);
		}

		public virtual void StaticParameterRules()
		{
			this.RuleFor(x => x.StaticParameter).Length(0, 2147483647);
		}

		public virtual void TimeoutInSecondRules()
		{
		}

		private async Task<bool> BeValidMachineByAssignedMachineId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.linkRepository.MachineByAssignedMachineId(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidChainByChainId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.linkRepository.ChainByChainId(id);

			return record != null;
		}

		private async Task<bool> BeValidLinkStatusByLinkStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.linkRepository.LinkStatusByLinkStatusId(id);

			return record != null;
		}

		private async Task<bool> BeUniqueByExternalId(ApiLinkRequestModel model,  CancellationToken cancellationToken)
		{
			Link record = await this.linkRepository.ByExternalId(model.ExternalId);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
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
    <Hash>e6863848dcd1c3336d600ce6dde2c1dd</Hash>
</Codenesium>*/