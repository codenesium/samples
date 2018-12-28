using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiShiftServerRequestModelValidator : AbstractValidator<ApiShiftServerRequestModel>
	{
		private int existingRecordId;

		protected IShiftRepository ShiftRepository { get; private set; }

		public AbstractApiShiftServerRequestModelValidator(IShiftRepository shiftRepository)
		{
			this.ShiftRepository = shiftRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiShiftServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EndTimeRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStartTimeEndTime).When(x => (!x?.StartTime.IsEmptyOrZeroOrNull() ?? false) || (!x?.EndTime.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftServerRequestModel.StartTime)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByName(ApiShiftServerRequestModel model,  CancellationToken cancellationToken)
		{
			Shift record = await this.ShiftRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ShiftID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByStartTimeEndTime(ApiShiftServerRequestModel model,  CancellationToken cancellationToken)
		{
			Shift record = await this.ShiftRepository.ByStartTimeEndTime(model.StartTime, model.EndTime);

			if (record == null || (this.existingRecordId != default(int) && record.ShiftID == this.existingRecordId))
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
    <Hash>109d39611d688fdf44075217890aaf59</Hash>
</Codenesium>*/