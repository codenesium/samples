using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesPersonServerModelMapper
	{
		public virtual ApiSalesPersonServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiSalesPersonServerRequestModel request)
		{
			var response = new ApiSalesPersonServerResponseModel();
			response.SetProperties(businessEntityID,
			                       request.Bonus,
			                       request.CommissionPct,
			                       request.ModifiedDate,
			                       request.Rowguid,
			                       request.SalesLastYear,
			                       request.SalesQuota,
			                       request.SalesYTD,
			                       request.TerritoryID);
			return response;
		}

		public virtual ApiSalesPersonServerRequestModel MapServerResponseToRequest(
			ApiSalesPersonServerResponseModel response)
		{
			var request = new ApiSalesPersonServerRequestModel();
			request.SetProperties(
				response.Bonus,
				response.CommissionPct,
				response.ModifiedDate,
				response.Rowguid,
				response.SalesLastYear,
				response.SalesQuota,
				response.SalesYTD,
				response.TerritoryID);
			return request;
		}

		public virtual ApiSalesPersonClientRequestModel MapServerResponseToClientRequest(
			ApiSalesPersonServerResponseModel response)
		{
			var request = new ApiSalesPersonClientRequestModel();
			request.SetProperties(
				response.Bonus,
				response.CommissionPct,
				response.ModifiedDate,
				response.Rowguid,
				response.SalesLastYear,
				response.SalesQuota,
				response.SalesYTD,
				response.TerritoryID);
			return request;
		}

		public JsonPatchDocument<ApiSalesPersonServerRequestModel> CreatePatch(ApiSalesPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesPersonServerRequestModel>();
			patch.Replace(x => x.Bonus, model.Bonus);
			patch.Replace(x => x.CommissionPct, model.CommissionPct);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalesLastYear, model.SalesLastYear);
			patch.Replace(x => x.SalesQuota, model.SalesQuota);
			patch.Replace(x => x.SalesYTD, model.SalesYTD);
			patch.Replace(x => x.TerritoryID, model.TerritoryID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>01530adbb98af70baf9ed1d3349889de</Hash>
</Codenesium>*/