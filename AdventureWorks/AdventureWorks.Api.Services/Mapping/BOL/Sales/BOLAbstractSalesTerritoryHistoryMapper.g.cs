using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesTerritoryHistoryMapper
	{
		public virtual BOSalesTerritoryHistory MapModelToBO(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel model
			)
		{
			BOSalesTerritoryHistory BOSalesTerritoryHistory = new BOSalesTerritoryHistory();

			BOSalesTerritoryHistory.SetProperties(
				businessEntityID,
				model.EndDate,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate,
				model.TerritoryID);
			return BOSalesTerritoryHistory;
		}

		public virtual ApiSalesTerritoryHistoryResponseModel MapBOToModel(
			BOSalesTerritoryHistory BOSalesTerritoryHistory)
		{
			if (BOSalesTerritoryHistory == null)
			{
				return null;
			}

			var model = new ApiSalesTerritoryHistoryResponseModel();

			model.SetProperties(BOSalesTerritoryHistory.BusinessEntityID, BOSalesTerritoryHistory.EndDate, BOSalesTerritoryHistory.ModifiedDate, BOSalesTerritoryHistory.Rowguid, BOSalesTerritoryHistory.StartDate, BOSalesTerritoryHistory.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesTerritoryHistoryResponseModel> MapBOToModel(
			List<BOSalesTerritoryHistory> BOs)
		{
			List<ApiSalesTerritoryHistoryResponseModel> response = new List<ApiSalesTerritoryHistoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dc40d8e0575dfc6639b041ba875cada3</Hash>
</Codenesium>*/