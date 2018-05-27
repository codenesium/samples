using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiShiftRequestModelValidator: AbstractValidator<ApiShiftRequestModel>
	{
		public new ValidationResult Validate(ApiShiftRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiShiftRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IShiftRepository ShiftRepository { get; set; }
		public virtual void EndTimeRules()
		{
			this.RuleFor(x => x.EndTime).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetStartTimeEndTime).When(x => x ?.EndTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.EndTime));
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x.StartTime).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetStartTimeEndTime).When(x => x ?.StartTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftRequestModel.StartTime));
		}

		private async Task<bool> BeUniqueGetName(ApiShiftRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.ShiftRepository.GetName(model.Name);

			return record == null;
		}
		private async Task<bool> BeUniqueGetStartTimeEndTime(ApiShiftRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.ShiftRepository.GetStartTimeEndTime(model.StartTime,model.EndTime);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>882a9d235aa169a3c096772b833e10ea</Hash>
</Codenesium>*/