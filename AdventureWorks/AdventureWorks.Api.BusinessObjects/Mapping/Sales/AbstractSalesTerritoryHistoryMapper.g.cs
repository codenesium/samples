using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesTerritoryHistoryMapper
	{
		public virtual DTOSalesTerritoryHistory MapModelToDTO(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel model
			)
		{
			DTOSalesTerritoryHistory dtoSalesTerritoryHistory = new DTOSalesTerritoryHistory();

			dtoSalesTerritoryHistory.SetProperties(
				businessEntityID,
				model.EndDate,
				model.ModifiedDate,
				model.Rowguid,
				model.StartDate,
				model.TerritoryID);
			return dtoSalesTerritoryHistory;
		}

		public virtual ApiSalesTerritoryHistoryResponseModel MapDTOToModel(
			DTOSalesTerritoryHistory dtoSalesTerritoryHistory)
		{
			if (dtoSalesTerritoryHistory == null)
			{
				return null;
			}

			var model = new ApiSalesTerritoryHistoryResponseModel();

			model.SetProperties(dtoSalesTerritoryHistory.BusinessEntityID, dtoSalesTerritoryHistory.EndDate, dtoSalesTerritoryHistory.ModifiedDate, dtoSalesTerritoryHistory.Rowguid, dtoSalesTerritoryHistory.StartDate, dtoSalesTerritoryHistory.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesTerritoryHistoryResponseModel> MapDTOToModel(
			List<DTOSalesTerritoryHistory> dtos)
		{
			List<ApiSalesTerritoryHistoryResponseModel> response = new List<ApiSalesTerritoryHistoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>02874c0036e7bf05581bbb98a097b86c</Hash>
</Codenesium>*/