using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesTerritoryMapper
	{
		public virtual DTOSalesTerritory MapModelToDTO(
			int territoryID,
			ApiSalesTerritoryRequestModel model
			)
		{
			DTOSalesTerritory dtoSalesTerritory = new DTOSalesTerritory();

			dtoSalesTerritory.SetProperties(
				territoryID,
				model.CostLastYear,
				model.CostYTD,
				model.CountryRegionCode,
				model.@Group,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesYTD);
			return dtoSalesTerritory;
		}

		public virtual ApiSalesTerritoryResponseModel MapDTOToModel(
			DTOSalesTerritory dtoSalesTerritory)
		{
			if (dtoSalesTerritory == null)
			{
				return null;
			}

			var model = new ApiSalesTerritoryResponseModel();

			model.SetProperties(dtoSalesTerritory.CostLastYear, dtoSalesTerritory.CostYTD, dtoSalesTerritory.CountryRegionCode, dtoSalesTerritory.@Group, dtoSalesTerritory.ModifiedDate, dtoSalesTerritory.Name, dtoSalesTerritory.Rowguid, dtoSalesTerritory.SalesLastYear, dtoSalesTerritory.SalesYTD, dtoSalesTerritory.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesTerritoryResponseModel> MapDTOToModel(
			List<DTOSalesTerritory> dtos)
		{
			List<ApiSalesTerritoryResponseModel> response = new List<ApiSalesTerritoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0e7fe7c19c8267b376087d5ddc8687e4</Hash>
</Codenesium>*/