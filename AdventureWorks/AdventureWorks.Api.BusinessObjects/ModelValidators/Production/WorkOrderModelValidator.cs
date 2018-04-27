using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class WorkOrderModelValidator: AbstractWorkOrderModelValidator, IWorkOrderModelValidator
	{
		public WorkOrderModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(WorkOrderModel model)
		{
			this.DueDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.ScrappedQtyRules();
			this.ScrapReasonIDRules();
			this.StartDateRules();
			this.StockedQtyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, WorkOrderModel model)
		{
			this.DueDateRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.ScrappedQtyRules();
			this.ScrapReasonIDRules();
			this.StartDateRules();
			this.StockedQtyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7bbfe2ff646a58349f7f236dcd372d0c</Hash>
</Codenesium>*/