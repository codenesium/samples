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
	public class ApiLinkServerRequestModelValidator : AbstractValidator<ApiLinkServerRequestModel>, IApiLinkServerRequestModelValidator
	{
		private int existingRecordId;

		protected ILinkRepository LinkRepository { get; private set; }

		public ApiLinkServerRequestModelValidator(ILinkRepository linkRepository)
		{
			this.LinkRepository = linkRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLinkServerRequestModel model)
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParametersRules();
			this.ExternalIdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParametersRules();
			this.TimeoutInSecondsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkServerRequestModel model)
		{
			this.AssignedMachineIdRules();
			this.ChainIdRules();
			this.DateCompletedRules();
			this.DateStartedRules();
			this.DynamicParametersRules();
			this.ExternalIdRules();
			this.LinkStatusIdRules();
			this.NameRules();
			this.OrderRules();
			this.ResponseRules();
			this.StaticParametersRules();
			this.TimeoutInSecondsRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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

		public virtual void DynamicParametersRules()
		{
			this.RuleFor(x => x.DynamicParameters).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
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

		public virtual void StaticParametersRules()
		{
			this.RuleFor(x => x.StaticParameters).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TimeoutInSecondsRules()
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
    <Hash>4dabd088f7b3edaa60713804217a3bea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/