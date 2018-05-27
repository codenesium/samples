using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPurchaseOrderHeaderRequestModelValidator: AbstractApiPurchaseOrderHeaderRequestModelValidator, IApiPurchaseOrderHeaderRequestModelValidator
	{
		public ApiPurchaseOrderHeaderRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel model)
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
    <Hash>eca5580f6e9474f368408a207f068a86</Hash>
</Codenesium>*/