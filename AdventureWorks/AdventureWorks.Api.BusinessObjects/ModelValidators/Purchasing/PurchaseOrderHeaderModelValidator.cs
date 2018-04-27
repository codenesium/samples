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
			this.EmployeeIDRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OrderDateRules();
			this.RevisionNumberRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TotalDueRules();
			this.VendorIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PurchaseOrderHeaderModel model)
		{
			this.EmployeeIDRules();
			this.FreightRules();
			this.ModifiedDateRules();
			this.OrderDateRules();
			this.RevisionNumberRules();
			this.ShipDateRules();
			this.ShipMethodIDRules();
			this.StatusRules();
			this.SubTotalRules();
			this.TaxAmtRules();
			this.TotalDueRules();
			this.VendorIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b2c18aee1820a051d5603b5445322b38</Hash>
</Codenesium>*/