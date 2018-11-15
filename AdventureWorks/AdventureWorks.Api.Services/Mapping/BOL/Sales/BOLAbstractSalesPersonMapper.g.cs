using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesPersonMapper
	{
		public virtual BOSalesPerson MapModelToBO(
			int businessEntityID,
			ApiSalesPersonServerRequestModel model
			)
		{
			BOSalesPerson boSalesPerson = new BOSalesPerson();
			boSalesPerson.SetProperties(
				businessEntityID,
				model.Bonus,
				model.CommissionPct,
				model.ModifiedDate,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesQuota,
				model.SalesYTD,
				model.TerritoryID);
			return boSalesPerson;
		}

		public virtual ApiSalesPersonServerResponseModel MapBOToModel(
			BOSalesPerson boSalesPerson)
		{
			var model = new ApiSalesPersonServerResponseModel();

			model.SetProperties(boSalesPerson.BusinessEntityID, boSalesPerson.Bonus, boSalesPerson.CommissionPct, boSalesPerson.ModifiedDate, boSalesPerson.Rowguid, boSalesPerson.SalesLastYear, boSalesPerson.SalesQuota, boSalesPerson.SalesYTD, boSalesPerson.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesPersonServerResponseModel> MapBOToModel(
			List<BOSalesPerson> items)
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
    <Hash>4fcc47c00cd276a1b4af587425ab2207</Hash>
</Codenesium>*/