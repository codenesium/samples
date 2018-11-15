using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiContactTypeServerModelMapper
	{
		public virtual ApiContactTypeServerResponseModel MapServerRequestToResponse(
			int contactTypeID,
			ApiContactTypeServerRequestModel request)
		{
			var response = new ApiContactTypeServerResponseModel();
			response.SetProperties(contactTypeID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiContactTypeServerRequestModel MapServerResponseToRequest(
			ApiContactTypeServerResponseModel response)
		{
			var request = new ApiContactTypeServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiContactTypeClientRequestModel MapServerResponseToClientRequest(
			ApiContactTypeServerResponseModel response)
		{
			var request = new ApiContactTypeClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiContactTypeServerRequestModel> CreatePatch(ApiContactTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiContactTypeServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2cfc80353ba7e37e1a9e34b174492910</Hash>
</Codenesium>*/