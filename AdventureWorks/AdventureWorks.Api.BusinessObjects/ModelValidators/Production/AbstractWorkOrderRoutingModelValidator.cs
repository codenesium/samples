using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public ILocationRepository LocationRepository { get; set; }
		public IWorkOrderRepository WorkOrderRepository { get; set; }
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
			this.RuleFor(x => x.LocationID).Must(this.BeValidLocation).When(x => x ?.LocationID != null).WithMessage("Invalid reference");
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

		private bool BeValidLocation(short id)
		{
			return this.LocationRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidWorkOrder(int id)
		{
			return this.WorkOrderRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ab9a729b143fee7af1f1c11b5478dd1b</Hash>
</Codenesium>*/