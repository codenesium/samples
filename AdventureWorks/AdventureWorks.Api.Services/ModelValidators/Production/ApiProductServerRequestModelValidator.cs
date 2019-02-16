using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductServerRequestModelValidator : AbstractApiProductServerRequestModelValidator, IApiProductServerRequestModelValidator
	{
		public ApiProductServerRequestModelValidator(IProductRepository productRepository)
			: base(productRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductServerRequestModel model)
		{
			this.ColorRules();
			this.DaysToManufactureRules();
			this.DiscontinuedDateRules();
			this.FinishedGoodsFlagRules();
			this.ListPriceRules();
			this.MakeFlagRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductLineRules();
			this.ProductModelIDRules();
			this.ProductNumberRules();
			this.ProductSubcategoryIDRules();
			this.ReorderPointRules();
			this.RowguidRules();
			this.SafetyStockLevelRules();
			this.SellEndDateRules();
			this.SellStartDateRules();
			this.SizeRules();
			this.SizeUnitMeasureCodeRules();
			this.StandardCostRules();
			this.StyleRules();
			this.WeightRules();
			this.WeightUnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductServerRequestModel model)
		{
			this.ColorRules();
			this.DaysToManufactureRules();
			this.DiscontinuedDateRules();
			this.FinishedGoodsFlagRules();
			this.ListPriceRules();
			this.MakeFlagRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductLineRules();
			this.ProductModelIDRules();
			this.ProductNumberRules();
			this.ProductSubcategoryIDRules();
			this.ReorderPointRules();
			this.RowguidRules();
			this.SafetyStockLevelRules();
			this.SellEndDateRules();
			this.SellStartDateRules();
			this.SizeRules();
			this.SizeUnitMeasureCodeRules();
			this.StandardCostRules();
			this.StyleRules();
			this.WeightRules();
			this.WeightUnitMeasureCodeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4f075321b3474af070e3af3f6f3dcc42</Hash>
</Codenesium>*/