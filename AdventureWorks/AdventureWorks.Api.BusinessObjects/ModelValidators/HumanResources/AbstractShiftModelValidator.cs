using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiShiftModelValidator: AbstractValidator<ApiShiftModel>
	{
		public new ValidationResult Validate(ApiShiftModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiShiftModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IShiftRepository ShiftRepository { get; set; }
		public virtual void EndTimeRules()
		{
			this.RuleFor(x => x.EndTime).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetStartTimeEndTime).When(x => x ?.EndTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftModel.EndTime));
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void StartTimeRules()
		{
			this.RuleFor(x => x.StartTime).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetStartTimeEndTime).When(x => x ?.StartTime != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShiftModel.StartTime));
		}

		private bool BeUniqueGetName(ApiShiftModel model)
		{
			return this.ShiftRepository.GetName(model.Name) == null;
		}

		private bool BeUniqueGetStartTimeEndTime(ApiShiftModel model)
		{
			return this.ShiftRepository.GetStartTimeEndTime(model.StartTime,model.EndTime) == null;
		}
	}
}

/*<Codenesium>
    <Hash>1e33a4f7917ced021d6e29941febd09f</Hash>
</Codenesium>*/