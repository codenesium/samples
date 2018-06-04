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
			BOSalesTaxRate BOSalesTaxRate = new BOSalesTaxRate();

			BOSalesTaxRate.SetProperties(
				salesTaxRateID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceID,
				model.TaxRate,
				model.TaxType);
			return BOSalesTaxRate;
		}

		public virtual ApiSalesTaxRateResponseModel MapBOToModel(
			BOSalesTaxRate BOSalesTaxRate)
		{
			if (BOSalesTaxRate == null)
			{
				return null;
			}

			var model = new ApiSalesTaxRateResponseModel();

			model.SetProperties(BOSalesTaxRate.ModifiedDate, BOSalesTaxRate.Name, BOSalesTaxRate.Rowguid, BOSalesTaxRate.SalesTaxRateID, BOSalesTaxRate.StateProvinceID, BOSalesTaxRate.TaxRate, BOSalesTaxRate.TaxType);

			return model;
		}

		public virtual List<ApiSalesTaxRateResponseModel> MapBOToModel(
			List<BOSalesTaxRate> BOs)
		{
			List<ApiSalesTaxRateResponseModel> response = new List<ApiSalesTaxRateResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>12b556d0d90d64d685a876fe19c97df2</Hash>
</Codenesium>*/