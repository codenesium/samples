using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLSalesTerritoryHistoryMapper
	{
		DTOSalesTerritoryHistory MapModelToDTO(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel model);

		ApiSalesTerritoryHistoryResponseModel MapDTOToModel(
			DTOSalesTerritoryHistory dtoSalesTerritoryHistory);

		List<ApiSalesTerritoryHistoryResponseModel> MapDTOToModel(
			List<DTOSalesTerritoryHistory> dtos);
	}
}

/*<Codenesium>
    <Hash>45c0486423f888aaab5fe0f6e5d3b84c</Hash>
</Codenesium>*/