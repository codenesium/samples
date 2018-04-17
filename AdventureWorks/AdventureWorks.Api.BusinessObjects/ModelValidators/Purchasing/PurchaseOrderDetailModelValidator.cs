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
			this.PurchaseOrderDetailIDRules();
			this.DueDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.UnitPriceRules();
			this.LineTotalRules();
			this.ReceivedQtyRules();
			this.RejectedQtyRules();
			this.StockedQtyRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PurchaseOrderDetailModel model)
		{
			this.PurchaseOrderDetailIDRules();
			this.DueDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.UnitPriceRules();
			this.LineTotalRules();
			this.ReceivedQtyRules();
			this.RejectedQtyRules();
			this.StockedQtyRules();
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
    <Hash>09937cf58be145816cb57be6552bf974</Hash>
</Codenesium>*/