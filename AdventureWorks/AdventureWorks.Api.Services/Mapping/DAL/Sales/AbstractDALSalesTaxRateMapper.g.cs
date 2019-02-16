using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesTaxRateMapper
	{
		public virtual SalesTaxRate MapModelToBO(
			int salesTaxRateID,
			ApiSalesTaxRateServerRequestModel model
			)
		{
			SalesTaxRate item = new SalesTaxRate();
			item.SetProperties(
				salesTaxRateID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceID,
				model.TaxRate,
				model.TaxType);
			return item;
		}

		public virtual ApiSalesTaxRateServerResponseModel MapBOToModel(
			SalesTaxRate item)
		{
			var model = new ApiSalesTaxRateServerResponseModel();

			model.SetProperties(item.SalesTaxRateID, item.ModifiedDate, item.Name, item.Rowguid, item.StateProvinceID, item.TaxRate, item.TaxType);

			return model;
		}

		public virtual List<ApiSalesTaxRateServerResponseModel> MapBOToModel(
			List<SalesTaxRate> items)
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
    <Hash>3a96468fd83c6ce8e6addf15dab2f3f8</Hash>
</Codenesium>*/