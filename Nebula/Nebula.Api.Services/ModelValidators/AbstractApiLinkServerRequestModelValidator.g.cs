using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiLinkServerRequestModelValidator : AbstractValidator<ApiLinkServerRequestModel>
	{
		private int existingRecordId;

		private ILinkRepository linkRepository;

		public AbstractApiLinkServerRequestModelValidator(ILinkRepository linkRepository)
		{
			this.linkRepository = linkRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AssignedMachineIdRules()
		{
			this.RuleFor(x => x.AssignedMachineId).MustAsync(this.BeValidMachineByAssignedMachineId).When(x => !x?.AssignedMachineId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void ChainIdRules()
		{
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => !x?.ExternalId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkServerRequestModel.ExternalId));
		}

		public virtual void LinkStatusIdRules()
		{
			this.RuleFor(x => x.LinkStatusId).MustAsync(this.BeValidLinkStatusByLinkStatusId).When(x => !x?.LinkStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
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

		private async Task<bool> BeValidLinkStatusByLinkStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.linkRepository.LinkStatusByLinkStatusId(id);

			return record != null;
		}

		private async Task<bool> BeUniqueByExternalId(ApiLinkServerRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>bdd561cc1e5313413e24405299f1abdb</Hash>
</Codenesium>*/