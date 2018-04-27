using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class PurchaseOrderDetailModelValidator: AbstractPurchaseOrderDetailModelValidator, IPurchaseOrderDetailModelValidator
	{
		public PurchaseOrderDetailModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PurchaseOrderDetailModel model)
		{
			this.DueDateRules();
			this.LineTotalRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.PurchaseOrderDetailIDRules();
			this.ReceivedQtyRules();
			this.RejectedQtyRules();
			this.StockedQtyRules();
			this.UnitPriceRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PurchaseOrderDetailModel model)
		{
			this.DueDateRules();
			this.LineTotalRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.PurchaseOrderDetailIDRules();
			this.ReceivedQtyRules();
			this.RejectedQtyRules();
			this.StockedQtyRules();
			this.UnitPriceRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>eb9fb8a85d78028b11318967031c59fd</Hash>
</Codenesium>*/