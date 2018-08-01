using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

			model.SetProperties(boSalesTaxRate.SalesTaxRateID, boSalesTaxRate.ModifiedDate, boSalesTaxRate.Name, boSalesTaxRate.Rowguid, boSalesTaxRate.StateProvinceID, boSalesTaxRate.TaxRate, boSalesTaxRate.TaxType);

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
    <Hash>5fe9f434600def26a1c80f56ac5ea4f5</Hash>
</Codenesium>*/