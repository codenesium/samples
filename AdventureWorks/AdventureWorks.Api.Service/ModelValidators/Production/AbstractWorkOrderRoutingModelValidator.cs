using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractWorkOrderRoutingModelValidator: AbstractValidator<WorkOrderRoutingModel>
	{
		public new ValidationResult Validate(WorkOrderRoutingModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(WorkOrderRoutingModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void OperationSequenceRules()
		{
			RuleFor(x => x.OperationSequence).NotNull();
		}

		public virtual void LocationIDRules()
		{
			RuleFor(x => x.LocationID).NotNull();
		}

		public virtual void ScheduledStartDateRules()
		{
			RuleFor(x => x.ScheduledStartDate).NotNull();
		}

		public virtual void ScheduledEndDateRules()
		{
			RuleFor(x => x.ScheduledEndDate).NotNull();
		}

		public virtual void ActualStartDateRules()
		{                       }

		public virtual void ActualEndDateRules()
		{                       }

		public virtual void ActualResourceHrsRules()
		{                       }

		public virtual void PlannedCostRules()
		{
			RuleFor(x => x.PlannedCost).NotNull();
		}

		public virtual void ActualCostRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>4ee518aae4fbf176ab5cf0e9aa08b8e8</Hash>
</Codenesium>*/