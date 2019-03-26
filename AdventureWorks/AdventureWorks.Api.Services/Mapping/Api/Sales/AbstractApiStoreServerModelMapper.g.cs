using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiStoreServerModelMapper
	{
		public virtual ApiStoreServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiStoreServerRequestModel request)
		{
			var response = new ApiStoreServerResponseModel();
			response.SetProperties(businessEntityID,
			                       request.Demographic,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.SalesPersonID);
			return response;
		}

		public virtual ApiStoreServerRequestModel MapServerResponseToRequest(
			ApiStoreServerResponseModel response)
		{
			var request = new ApiStoreServerRequestModel();
			request.SetProperties(
				response.Demographic,
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.SalesPersonID);
			return request;
		}

		public virtual ApiStoreClientRequestModel MapServerResponseToClientRequest(
			ApiStoreServerResponseModel response)
		{
			var request = new ApiStoreClientRequestModel();
			request.SetProperties(
				response.Demographic,
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.SalesPersonID);
			return request;
		}

		public JsonPatchDocument<ApiStoreServerRequestModel> CreatePatch(ApiStoreServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStoreServerRequestModel>();
			patch.Replace(x => x.Demographic, model.Demographic);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalesPersonID, model.SalesPersonID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b5857046cb9d8b34c834effa7fe19edb</Hash>
</Codenesium>*/