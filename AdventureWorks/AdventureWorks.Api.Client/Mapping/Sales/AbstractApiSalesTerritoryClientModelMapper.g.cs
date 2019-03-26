using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiSalesTerritoryModelMapper
	{
		public virtual ApiSalesTerritoryClientResponseModel MapClientRequestToResponse(
			int territoryID,
			ApiSalesTerritoryClientRequestModel request)
		{
			var response = new ApiSalesTerritoryClientResponseModel();
			response.SetProperties(territoryID,
			                       request.CostLastYear,
			                       request.CostYTD,
			                       request.CountryRegionCode,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.ReservedGroup,
			                       request.Rowguid,
			                       request.SalesLastYear,
			                       request.SalesYTD);
			return response;
		}

		public virtual ApiSalesTerritoryClientRequestModel MapClientResponseToRequest(
			ApiSalesTerritoryClientResponseModel response)
		{
			var request = new ApiSalesTerritoryClientRequestModel();
			request.SetProperties(
				response.CostLastYear,
				response.CostYTD,
				response.CountryRegionCode,
				response.ModifiedDate,
				response.Name,
				response.ReservedGroup,
				response.Rowguid,
				response.SalesLastYear,
				response.SalesYTD);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5fdc4dfad344fffe3c987eec3aee2f88</Hash>
</Codenesium>*/