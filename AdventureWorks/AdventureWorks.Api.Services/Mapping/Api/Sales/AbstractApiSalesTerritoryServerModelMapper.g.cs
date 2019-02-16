using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesTerritoryServerModelMapper
	{
		public virtual ApiSalesTerritoryServerResponseModel MapServerRequestToResponse(
			int territoryID,
			ApiSalesTerritoryServerRequestModel request)
		{
			var response = new ApiSalesTerritoryServerResponseModel();
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

		public virtual ApiSalesTerritoryServerRequestModel MapServerResponseToRequest(
			ApiSalesTerritoryServerResponseModel response)
		{
			var request = new ApiSalesTerritoryServerRequestModel();
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

		public virtual ApiSalesTerritoryClientRequestModel MapServerResponseToClientRequest(
			ApiSalesTerritoryServerResponseModel response)
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

		public JsonPatchDocument<ApiSalesTerritoryServerRequestModel> CreatePatch(ApiSalesTerritoryServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesTerritoryServerRequestModel>();
			patch.Replace(x => x.CostLastYear, model.CostLastYear);
			patch.Replace(x => x.CostYTD, model.CostYTD);
			patch.Replace(x => x.CountryRegionCode, model.CountryRegionCode);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalesLastYear, model.SalesLastYear);
			patch.Replace(x => x.SalesYTD, model.SalesYTD);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>aae534e47ef08f560c06a98994d2038c</Hash>
</Codenesium>*/