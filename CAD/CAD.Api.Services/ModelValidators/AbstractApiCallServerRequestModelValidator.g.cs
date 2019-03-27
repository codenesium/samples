using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiCallServerRequestModelValidator : AbstractValidator<ApiCallServerRequestModel>
	{
		private int existingRecordId;

		protected ICallRepository CallRepository { get; private set; }

		public AbstractApiCallServerRequestModelValidator(ICallRepository callRepository)
		{
			this.CallRepository = callRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AddressIdRules()
		{
			this.RuleFor(x => x.AddressId).MustAsync(this.BeValidAddressByAddressId).When(x => !x?.AddressId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void CallDispositionIdRules()
		{
			this.RuleFor(x => x.CallDispositionId).MustAsync(this.BeValidCallDispositionByCallDispositionId).When(x => !x?.CallDispositionId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void CallStatusIdRules()
		{
			this.RuleFor(x => x.CallStatusId).MustAsync(this.BeValidCallStatusByCallStatusId).When(x => !x?.CallStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void CallStringRules()
		{
			this.RuleFor(x => x.CallString).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.CallString).Length(0, 24).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CallTypeIdRules()
		{
			this.RuleFor(x => x.CallTypeId).MustAsync(this.BeValidCallTypeByCallTypeId).When(x => !x?.CallTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DateClearedRules()
		{
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void DateDispatchedRules()
		{
		}

		public virtual void QuickCallNumberRules()
		{
		}

		protected async Task<bool> BeValidAddressByAddressId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CallRepository.AddressByAddressId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidCallDispositionByCallDispositionId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CallRepository.CallDispositionByCallDispositionId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidCallStatusByCallStatusId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CallRepository.CallStatusByCallStatusId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidCallTypeByCallTypeId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CallRepository.CallTypeByCallTypeId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>66969304cc3452b7981418b961da60dd</Hash>
</Codenesium>*/