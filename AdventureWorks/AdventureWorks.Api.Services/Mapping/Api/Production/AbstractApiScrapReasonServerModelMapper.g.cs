using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiScrapReasonServerModelMapper
	{
		public virtual ApiScrapReasonServerResponseModel MapServerRequestToResponse(
			short scrapReasonID,
			ApiScrapReasonServerRequestModel request)
		{
			var response = new ApiScrapReasonServerResponseModel();
			response.SetProperties(scrapReasonID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiScrapReasonServerRequestModel MapServerResponseToRequest(
			ApiScrapReasonServerResponseModel response)
		{
			var request = new ApiScrapReasonServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiScrapReasonClientRequestModel MapServerResponseToClientRequest(
			ApiScrapReasonServerResponseModel response)
		{
			var request = new ApiScrapReasonClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiScrapReasonServerRequestModel> CreatePatch(ApiScrapReasonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiScrapReasonServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>6dd22f27223b5c90e88d1c49826280b4</Hash>
</Codenesium>*/