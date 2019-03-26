using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductDescriptionServerModelMapper
	{
		public virtual ApiProductDescriptionServerResponseModel MapServerRequestToResponse(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel request)
		{
			var response = new ApiProductDescriptionServerResponseModel();
			response.SetProperties(productDescriptionID,
			                       request.Description,
			                       request.ModifiedDate,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductDescriptionServerRequestModel MapServerResponseToRequest(
			ApiProductDescriptionServerResponseModel response)
		{
			var request = new ApiProductDescriptionServerRequestModel();
			request.SetProperties(
				response.Description,
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}

		public virtual ApiProductDescriptionClientRequestModel MapServerResponseToClientRequest(
			ApiProductDescriptionServerResponseModel response)
		{
			var request = new ApiProductDescriptionClientRequestModel();
			request.SetProperties(
				response.Description,
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiProductDescriptionServerRequestModel> CreatePatch(ApiProductDescriptionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProductDescriptionServerRequestModel>();
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>27ef69de866af840fb8e0782883540e4</Hash>
</Codenesium>*/