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
			this.ProductIDRules();
			this.OrderQtyRules();
			this.StockedQtyRules();
			this.ScrappedQtyRules();
			this.StartDateRules();
			this.EndDateRules();
			this.DueDateRules();
			this.ScrapReasonIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, WorkOrderModel model)
		{
			this.ProductIDRules();
			this.OrderQtyRules();
			this.StockedQtyRules();
			this.ScrappedQtyRules();
			this.StartDateRules();
			this.EndDateRules();
			this.DueDateRules();
			this.ScrapReasonIDRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>37a3c3cf2bbbe286a27949bd55e57d1e</Hash>
</Codenesium>*/