using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiPurchaseOrderDetailRequestModelValidator: AbstractApiPurchaseOrderDetailRequestModelValidator, IApiPurchaseOrderDetailRequestModelValidator
	{
		public ApiPurchaseOrderDetailRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderDetailRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel model)
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
    <Hash>9199af8ba869806bb1e20fbde0acd57b</Hash>
</Codenesium>*/