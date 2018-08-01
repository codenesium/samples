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
			this.RuleFor(x => x.AssignedMachineId).MustAsync(this.BeValidMachine).When(x => x?.AssignedMachineId != null).WithMessage("Invalid reference");
		}

		public virtual void ChainIdRules()
		{
			this.RuleFor(x => x.ChainId).MustAsync(this.BeValidChain).When(x => x?.ChainId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCompletedRules()
		{
		}

		public virtual void DateStartedRules()
		{
		}

		public virtual void DynamicParametersRules()
		{
			this.RuleFor(x => x.DynamicParameters).Length(0, 2147483647);
		}

		public virtual void ExternalIdRules()
		{
		}

		public virtual void LinkStatusIdRules()
		{
			this.RuleFor(x => x.LinkStatusId).MustAsync(this.BeValidLinkStatus).When(x => x?.LinkStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrderRules()
		{
		}

		public virtual void ResponseRules()
		{
			this.RuleFor(x => x.Response).Length(0, 2147483647);
		}

		public virtual void StaticParametersRules()
		{
			this.RuleFor(x => x.StaticParameters).Length(0, 2147483647);
		}

		public virtual void TimeoutInSecondsRules()
		{
		}

		private async Task<bool> BeValidMachine(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.linkRepository.GetMachine(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidChain(int id,  CancellationToken cancellationToken)
		{
			var record = await this.linkRepository.GetChain(id);

			return record != null;
		}

		private async Task<bool> BeValidLinkStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.linkRepository.GetLinkStatus(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>94675d8d6f2c5092adf6a0be7048f915</Hash>
</Codenesium>*/