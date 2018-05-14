using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPurchaseOrderHeaderModelValidator: AbstractApiPurchaseOrderHeaderModelValidator, IApiPurchaseOrderHeaderModelValidator
	{
		public ApiPurchaseOrderHeaderModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderModel model)
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
    <Hash>15ad00f7d67221950d14245bce738476</Hash>
</Codenesium>*/