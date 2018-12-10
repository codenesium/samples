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
	public abstract class AbstractApiLinkServerRequestModelValidator : AbstractValidator<ApiLinkServerRequestModel>
	{
		private int existingRecordId;

		protected ILinkRepository LinkRepository { get; private set; }

		public AbstractApiLinkServerRequestModelValidator(ILinkRepository linkRepository)
		{
			this.LinkRepository = linkRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AssignedMachineIdRules()
		{
			this.RuleFor(x => x.AssignedMachineId).MustAsync(this.BeValidMachineByAssignedMachineId).When(x => !x?.AssignedMachineId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ChainIdRules()
		{
			this.RuleFor(x => x.ChainId).MustAsync(this.BeValidChainByChainId).When(x => !x?.ChainId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DateCompletedRules()
		{
		}

		public virtual void DateStartedRules()
		{
		}

		public virtual void DynamicParameterRules()
		{
			this.RuleFor(x => x.DynamicParameter).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByExternalId).When(x => (!x?.ExternalId.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkServerRequestModel.ExternalId)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void LinkStatusIdRules()
		{
			this.RuleFor(x => x.LinkStatusId).MustAsync(this.BeValidLinkStatusByLinkStatusId).When(x => !x?.LinkStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void OrderRules()
		{
		}

		public virtual void ResponseRules()
		{
			this.RuleFor(x => x.Response).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void StaticParameterRules()
		{
			this.RuleFor(x => x.StaticParameter).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TimeoutInSecondRules()
		{
		}

		protected async Task<bool> BeValidMachineByAssignedMachineId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.LinkRepository.MachineByAssignedMachineId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidChainByChainId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.LinkRepository.ChainByChainId(id);

			return record != null;
		}

		protected async Task<bool> BeValidLinkStatusByLinkStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.LinkRepository.LinkStatusByLinkStatusId(id);

			return record != null;
		}

		protected async Task<bool> BeUniqueByExternalId(ApiLinkServerRequestModel model,  CancellationToken cancellationToken)
		{
			Link record = await this.LinkRepository.ByExternalId(model.ExternalId);

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
    <Hash>776aa21328bab152487a81653c436918</Hash>
</Codenesium>*/