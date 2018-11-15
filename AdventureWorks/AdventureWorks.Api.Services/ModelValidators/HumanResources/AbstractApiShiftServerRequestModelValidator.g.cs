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

		private IShiftRepository shiftRepository;

		public AbstractApiShiftServerRequestModelValidator(IShiftRepository shiftRepository)
		{
			this.shiftRepository = shiftRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiShiftServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EndTimeRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStartTimeEndTime).When(x => !x?.EndTime.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftServerRequestModel.EndTime));
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStartTimeEndTime).When(x => !x?.StartTime.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftServerRequestModel.StartTime));
		}

		private async Task<bool> BeUniqueByName(ApiShiftServerRequestModel model,  CancellationToken cancellationToken)
		{
			Shift record = await this.shiftRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ShiftID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByStartTimeEndTime(ApiShiftServerRequestModel model,  CancellationToken cancellationToken)
		{
			Shift record = await this.shiftRepository.ByStartTimeEndTime(model.StartTime, model.EndTime);

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
    <Hash>145d801ca0436657b5b36a9eb6085d87</Hash>
</Codenesium>*/