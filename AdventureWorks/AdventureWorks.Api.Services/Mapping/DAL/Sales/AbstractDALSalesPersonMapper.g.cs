using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesPersonMapper
	{
		public virtual SalesPerson MapModelToBO(
			int businessEntityID,
			ApiSalesPersonServerRequestModel model
			)
		{
			SalesPerson item = new SalesPerson();
			item.SetProperties(
				businessEntityID,
				model.Bonus,
				model.CommissionPct,
				model.ModifiedDate,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesQuota,
				model.SalesYTD,
				model.TerritoryID);
			return item;
		}

		public virtual ApiSalesPersonServerResponseModel MapBOToModel(
			SalesPerson item)
		{
			var model = new ApiSalesPersonServerResponseModel();

			model.SetProperties(item.BusinessEntityID, item.Bonus, item.CommissionPct, item.ModifiedDate, item.Rowguid, item.SalesLastYear, item.SalesQuota, item.SalesYTD, item.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesPersonServerResponseModel> MapBOToModel(
			List<SalesPerson> items)
		{
			List<ApiSalesPersonServerResponseModel> response = new List<ApiSalesPersonServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>13230624544b01629636167191e2524a</Hash>
</Codenesium>*/