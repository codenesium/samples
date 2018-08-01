using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiProductModelModelMapper
	{
		public virtual ApiProductModelResponseModel MapRequestToResponse(
			int productModelID,
			ApiProductModelRequestModel request)
		{
			var response = new ApiProductModelResponseModel();
			response.SetProperties(productModelID,
			                       request.CatalogDescription,
			                       request.Instruction,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductModelRequestModel MapResponseToRequest(
			ApiProductModelResponseModel response)
		{
			var request = new ApiProductModelRequestModel();
			request.SetProperties(
				response.CatalogDescription,
				response.Instruction,
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiProductModelRequestModel> CreatePatch(ApiProductModelRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductModelRequestModel>();
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
    <Hash>493c4253b6dfde7f8bb5e1e1cba548d1</Hash>
</Codenesium>*/