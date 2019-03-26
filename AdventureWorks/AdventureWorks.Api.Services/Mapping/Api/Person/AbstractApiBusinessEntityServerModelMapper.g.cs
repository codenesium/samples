using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiBusinessEntityServerModelMapper
	{
		public virtual ApiBusinessEntityServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityServerRequestModel request)
		{
			var response = new ApiBusinessEntityServerResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiBusinessEntityServerRequestModel MapServerResponseToRequest(
			ApiBusinessEntityServerResponseModel response)
		{
			var request = new ApiBusinessEntityServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}

		public virtual ApiBusinessEntityClientRequestModel MapServerResponseToClientRequest(
			ApiBusinessEntityServerResponseModel response)
		{
			var request = new ApiBusinessEntityClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiBusinessEntityServerRequestModel> CreatePatch(ApiBusinessEntityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBusinessEntityServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>621c4555e4f57af2d6f44be3054b2524</Hash>
</Codenesium>*/