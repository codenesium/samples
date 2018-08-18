using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesPersonMapper
	{
		public virtual BOSalesPerson MapModelToBO(
			int businessEntityID,
			ApiSalesPersonRequestModel model
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

		public virtual ApiSalesPersonResponseModel MapBOToModel(
			BOSalesPerson boSalesPerson)
		{
			var model = new ApiSalesPersonResponseModel();

			model.SetProperties(boSalesPerson.BusinessEntityID, boSalesPerson.Bonus, boSalesPerson.CommissionPct, boSalesPerson.ModifiedDate, boSalesPerson.Rowguid, boSalesPerson.SalesLastYear, boSalesPerson.SalesQuota, boSalesPerson.SalesYTD, boSalesPerson.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesPersonResponseModel> MapBOToModel(
			List<BOSalesPerson> items)
		{
			List<ApiSalesPersonResponseModel> response = new List<ApiSalesPersonResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1163df24b1188e443c3c13ecd2d1a1d9</Hash>
</Codenesium>*/