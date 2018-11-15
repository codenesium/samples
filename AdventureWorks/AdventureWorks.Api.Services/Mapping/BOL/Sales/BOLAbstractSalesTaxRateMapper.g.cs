using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesTaxRateMapper
	{
		public virtual BOSalesTaxRate MapModelToBO(
			int salesTaxRateID,
			ApiSalesTaxRateServerRequestModel model
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

		public virtual ApiSalesTaxRateServerResponseModel MapBOToModel(
			BOSalesTaxRate boSalesTaxRate)
		{
			var model = new ApiSalesTaxRateServerResponseModel();

			model.SetProperties(boSalesTaxRate.SalesTaxRateID, boSalesTaxRate.ModifiedDate, boSalesTaxRate.Name, boSalesTaxRate.Rowguid, boSalesTaxRate.StateProvinceID, boSalesTaxRate.TaxRate, boSalesTaxRate.TaxType);

			return model;
		}

		public virtual List<ApiSalesTaxRateServerResponseModel> MapBOToModel(
			List<BOSalesTaxRate> items)
		{
			List<ApiSalesTaxRateServerResponseModel> response = new List<ApiSalesTaxRateServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3af4650e490ec5365b45c6332fecc7b2</Hash>
</Codenesium>*/