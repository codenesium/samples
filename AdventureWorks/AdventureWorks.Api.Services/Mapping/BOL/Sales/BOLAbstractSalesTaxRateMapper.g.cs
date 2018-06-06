using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesTaxRateMapper
	{
		public virtual BOSalesTaxRate MapModelToBO(
			int salesTaxRateID,
			ApiSalesTaxRateRequestModel model
			)
		{
			BOSalesTaxRate boSalesTaxRate = new BOSalesTaxRate();

			boSalesTaxRate.SetProperties(
				salesTaxRateID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceID,
				model.TaxRate,
				model.TaxType);
			return boSalesTaxRate;
		}

		public virtual ApiSalesTaxRateResponseModel MapBOToModel(
			BOSalesTaxRate boSalesTaxRate)
		{
			var model = new ApiSalesTaxRateResponseModel();

			model.SetProperties(boSalesTaxRate.ModifiedDate, boSalesTaxRate.Name, boSalesTaxRate.Rowguid, boSalesTaxRate.SalesTaxRateID, boSalesTaxRate.StateProvinceID, boSalesTaxRate.TaxRate, boSalesTaxRate.TaxType);

			return model;
		}

		public virtual List<ApiSalesTaxRateResponseModel> MapBOToModel(
			List<BOSalesTaxRate> items)
		{
			List<ApiSalesTaxRateResponseModel> response = new List<ApiSalesTaxRateResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c6f42c6fce0ddd02032f0696432d97c6</Hash>
</Codenesium>*/