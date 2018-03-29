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

		public IWorkOrderRepository WorkOrderRepository {get; set;}
		public ILocationRepository LocationRepository {get; set;}
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
			RuleFor(x => x.LocationID).Must(BeValidLocation).When(x => x ?.LocationID != null).WithMessage("Invalid reference");
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

		public bool BeValidWorkOrder(int id)
		{
			Response response = new Response();

			this.WorkOrderRepository.GetById(id,response);
			return response.WorkOrders.Count > 0;
		}

		public bool BeValidLocation(short id)
		{
			Response response = new Response();

			this.LocationRepository.GetById(id,response);
			return response.Locations.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>5418f9a3cbad0331b0818ba11df8599d</Hash>
</Codenesium>*/