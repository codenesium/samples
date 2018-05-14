using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiWorkOrderRoutingModelValidator: AbstractValidator<ApiWorkOrderRoutingModel>
	{
		public new ValidationResult Validate(ApiWorkOrderRoutingModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiWorkOrderRoutingModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ActualCostRules()
		{                       }

		public virtual void ActualEndDateRules()
		{                       }

		public virtual void ActualResourceHrsRules()
		{                       }

		public virtual void ActualStartDateRules()
		{                       }

		public virtual void LocationIDRules()
		{
			this.RuleFor(x => x.LocationID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OperationSequenceRules()
		{
			this.RuleFor(x => x.OperationSequence).NotNull();
		}

		public virtual void PlannedCostRules()
		{
			this.RuleFor(x => x.PlannedCost).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void ScheduledEndDateRules()
		{
			this.RuleFor(x => x.ScheduledEndDate).NotNull();
		}

		public virtual void ScheduledStartDateRules()
		{
			this.RuleFor(x => x.ScheduledStartDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>0586e60e70d25cc36c3fc27c8c5ef912</Hash>
</Codenesium>*/