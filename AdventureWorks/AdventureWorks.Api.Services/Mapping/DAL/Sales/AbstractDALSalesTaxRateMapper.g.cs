using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesTaxRateMapper
	{
		public virtual SalesTaxRate MapModelToEntity(
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

		public virtual ApiSalesTaxRateServerResponseModel MapEntityToModel(
			SalesTaxRate item)
		{
			var model = new ApiSalesTaxRateServerResponseModel();

			model.SetProperties(item.SalesTaxRateID,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid,
			                    item.StateProvinceID,
			                    item.TaxRate,
			                    item.TaxType);

			return model;
		}

		public virtual List<ApiSalesTaxRateServerResponseModel> MapEntityToModel(
			List<SalesTaxRate> items)
		{
			List<ApiSalesTaxRateServerResponseModel> response = new List<ApiSalesTaxRateServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b576b2cfe17ecc0bae651ce1742e3b1a</Hash>
</Codenesium>*/