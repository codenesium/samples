using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductModelServerModelMapper
	{
		public virtual ApiProductModelServerResponseModel MapServerRequestToResponse(
			int productModelID,
			ApiProductModelServerRequestModel request)
		{
			var response = new ApiProductModelServerResponseModel();
			response.SetProperties(productModelID,
			                       request.CatalogDescription,
			                       request.Instruction,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductModelServerRequestModel MapServerResponseToRequest(
			ApiProductModelServerResponseModel response)
		{
			var request = new ApiProductModelServerRequestModel();
			request.SetProperties(
				response.CatalogDescription,
				response.Instruction,
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public virtual ApiProductModelClientRequestModel MapServerResponseToClientRequest(
			ApiProductModelServerResponseModel response)
		{
			var request = new ApiProductModelClientRequestModel();
			request.SetProperties(
				response.CatalogDescription,
				response.Instruction,
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiProductModelServerRequestModel> CreatePatch(ApiProductModelServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductModelServerRequestModel>();
			patch.Replace(x => x.CatalogDescription, model.CatalogDescription);
			patch.Replace(x => x.Instruction, model.Instruction);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d101485ad3d25a1a4813fd6d93a92389</Hash>
</Codenesium>*/