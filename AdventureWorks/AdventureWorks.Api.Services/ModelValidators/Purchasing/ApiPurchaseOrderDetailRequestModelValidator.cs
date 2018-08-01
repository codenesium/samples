using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiPurchaseOrderDetailRequestModelValidator : AbstractApiPurchaseOrderDetailRequestModelValidator, IApiPurchaseOrderDetailRequestModelValidator
	{
		public ApiPurchaseOrderDetailRequestModelValidator(IPurchaseOrderDetailRepository purchaseOrderDetailRepository)
			: base(purchaseOrderDetailRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>da7ee41224b10019fb9e6ecda88ed5d4</Hash>
</Codenesium>*/