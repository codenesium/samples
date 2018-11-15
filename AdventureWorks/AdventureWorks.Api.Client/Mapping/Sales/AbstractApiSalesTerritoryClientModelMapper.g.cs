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
			                       request.@Group,
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
				response.@Group,
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
    <Hash>e76bd42f9c123c6660086ebeb46f3ac2</Hash>
</Codenesium>*/