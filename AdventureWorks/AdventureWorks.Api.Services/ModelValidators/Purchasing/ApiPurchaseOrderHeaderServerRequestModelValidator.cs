using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPurchaseOrderHeaderServerRequestModelValidator : AbstractApiPurchaseOrderHeaderServerRequestModelValidator, IApiPurchaseOrderHeaderServerRequestModelValidator
	{
		public ApiPurchaseOrderHeaderServerRequestModelValidator(IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository)
			: base(purchaseOrderHeaderRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderServerRequestModel model)
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>fca449e978e443e93db061b644465c6d</Hash>
</Codenesium>*/