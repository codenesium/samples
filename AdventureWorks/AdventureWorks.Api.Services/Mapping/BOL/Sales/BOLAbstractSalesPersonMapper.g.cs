using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesPersonMapper
	{
		public virtual BOSalesPerson MapModelToBO(
			int businessEntityID,
			ApiSalesPersonRequestModel model
			)
		{
			BOSalesPerson BOSalesPerson = new BOSalesPerson();

			BOSalesPerson.SetProperties(
				businessEntityID,
				model.Bonus,
				model.CommissionPct,
				model.ModifiedDate,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesQuota,
				model.SalesYTD,
				model.TerritoryID);
			return BOSalesPerson;
		}

		public virtual ApiSalesPersonResponseModel MapBOToModel(
			BOSalesPerson BOSalesPerson)
		{
			if (BOSalesPerson == null)
			{
				return null;
			}

			var model = new ApiSalesPersonResponseModel();

			model.SetProperties(BOSalesPerson.Bonus, BOSalesPerson.BusinessEntityID, BOSalesPerson.CommissionPct, BOSalesPerson.ModifiedDate, BOSalesPerson.Rowguid, BOSalesPerson.SalesLastYear, BOSalesPerson.SalesQuota, BOSalesPerson.SalesYTD, BOSalesPerson.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesPersonResponseModel> MapBOToModel(
			List<BOSalesPerson> BOs)
		{
			List<ApiSalesPersonResponseModel> response = new List<ApiSalesPersonResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ba57102dac93ee88ff2ba66e06109a30</Hash>
</Codenesium>*/