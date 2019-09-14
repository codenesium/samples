using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiSpaceFeatureServerModelMapper : IApiSpaceFeatureServerModelMapper
	{
		public virtual ApiSpaceFeatureServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpaceFeatureServerRequestModel request)
		{
			var response = new ApiSpaceFeatureServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSpaceFeatureServerRequestModel MapServerResponseToRequest(
			ApiSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceFeatureServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiSpaceFeatureClientRequestModel MapServerResponseToClientRequest(
			ApiSpaceFeatureServerResponseModel response)
		{
			var request = new ApiSpaceFeatureClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiSpaceFeatureServerRequestModel> CreatePatch(ApiSpaceFeatureServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSpaceFeatureServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cd14ef9dcbdd863990e80799deb0e507</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/