using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiStudioServerModelMapper : IApiStudioServerModelMapper
	{
		public virtual ApiStudioServerResponseModel MapServerRequestToResponse(
			int id,
			ApiStudioServerRequestModel request)
		{
			var response = new ApiStudioServerResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.City,
			                       request.Name,
			                       request.Province,
			                       request.Website,
			                       request.Zip);
			return response;
		}

		public virtual ApiStudioServerRequestModel MapServerResponseToRequest(
			ApiStudioServerResponseModel response)
		{
			var request = new ApiStudioServerRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.Name,
				response.Province,
				response.Website,
				response.Zip);
			return request;
		}

		public virtual ApiStudioClientRequestModel MapServerResponseToClientRequest(
			ApiStudioServerResponseModel response)
		{
			var request = new ApiStudioClientRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.Name,
				response.Province,
				response.Website,
				response.Zip);
			return request;
		}

		public JsonPatchDocument<ApiStudioServerRequestModel> CreatePatch(ApiStudioServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStudioServerRequestModel>();
			patch.Replace(x => x.Address1, model.Address1);
			patch.Replace(x => x.Address2, model.Address2);
			patch.Replace(x => x.City, model.City);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Province, model.Province);
			patch.Replace(x => x.Website, model.Website);
			patch.Replace(x => x.Zip, model.Zip);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8c42aa9423fd645ffa9fa9cbce340064</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/