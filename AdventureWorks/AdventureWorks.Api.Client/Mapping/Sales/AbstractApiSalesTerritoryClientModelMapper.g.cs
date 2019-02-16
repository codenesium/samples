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
				response.Rowguid,
				response.SalesLastYear,
				response.SalesYTD);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>bc9b92c3097f6f9c0a0ef6e31f2850e6</Hash>
</Codenesium>*/