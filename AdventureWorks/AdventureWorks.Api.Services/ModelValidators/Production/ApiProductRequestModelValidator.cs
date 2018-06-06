using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductRequestModelValidator: AbstractApiProductRequestModelValidator, IApiProductRequestModelValidator
	{
		public ApiProductRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model)
		{
			this.@ClassRules();
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model)
		{
			this.@ClassRules();
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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a90edb9b2ad77a4076453fd6f2c12d7f</Hash>
</Codenesium>*/