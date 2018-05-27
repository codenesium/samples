using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesTerritoryMapper
	{
		DTOSalesTerritory MapModelToDTO(
			int territoryID,
			ApiSalesTerritoryRequestModel model);

		ApiSalesTerritoryResponseModel MapDTOToModel(
			DTOSalesTerritory dtoSalesTerritory);

		List<ApiSalesTerritoryResponseModel> MapDTOToModel(
			List<DTOSalesTerritory> dtos);
	}
}

/*<Codenesium>
    <Hash>d4d67a8d0727de4c9d575fd908d297c5</Hash>
</Codenesium>*/