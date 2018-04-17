using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class PurchaseOrderHeaderModelValidator: AbstractPurchaseOrderHeaderModelValidator, IPurchaseOrderHeaderModelValidator
	{
		public PurchaseOrderHeaderModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PurchaseOrderHeaderModel model)
		{
			this.RevisionNumberRules();
			this.StatusRules();
			this.EmployeeIDRules();
			this.VendorIDRules();
			this.ShipMethodIDRules();
			this.OrderDateRules();
			this.ShipDateRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.FreightRules();
			this.TotalDueRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PurchaseOrderHeaderModel model)
		{
			this.RevisionNumberRules();
			this.StatusRules();
			this.EmployeeIDRules();
			this.VendorIDRules();
			this.ShipMethodIDRules();
			this.OrderDateRules();
			this.ShipDateRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.FreightRules();
			this.TotalDueRules();
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
    <Hash>cb22f1d12157b935658d0654f6f85665</Hash>
</Codenesium>*/