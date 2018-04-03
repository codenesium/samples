using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractWorkOrderModelValidator: AbstractValidator<WorkOrderModel>
	{
		public new ValidationResult Validate(WorkOrderModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(WorkOrderModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void OrderQtyRules()
		{
			RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void StockedQtyRules()
		{
			RuleFor(x => x.StockedQty).NotNull();
		}

		public virtual void ScrappedQtyRules()
		{
			RuleFor(x => x.ScrappedQty).NotNull();
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void DueDateRules()
		{
			RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void ScrapReasonIDRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>93da7d309683ee2346b8fc56c53b99bf</Hash>
</Codenesium>*/