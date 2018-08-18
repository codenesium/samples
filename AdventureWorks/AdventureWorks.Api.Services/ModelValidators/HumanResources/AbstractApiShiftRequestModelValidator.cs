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
	public abstract class AbstractApiShiftRequestModelValidator : AbstractValidator<ApiShiftRequestModel>
	{
		private int existingRecordId;

		private IShiftRepository shiftRepository;

		public AbstractApiShiftRequestModelValidator(IShiftRepository shiftRepository)
		{
			this.shiftRepository = shiftRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiShiftRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EndTimeRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStartTimeEndTime).When(x => x?.EndTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.EndTime));
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStartTimeEndTime).When(x => x?.StartTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.StartTime));
		}

		private async Task<bool> BeUniqueByName(ApiShiftRequestModel model,  CancellationToken cancellationToken)
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

		private async Task<bool> BeUniqueByStartTimeEndTime(ApiShiftRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>dafd23fc6b65dc556f288ef54d01774c</Hash>
</Codenesium>*/