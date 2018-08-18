using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiContactTypeModelMapper
	{
		public virtual ApiContactTypeResponseModel MapRequestToResponse(
			int contactTypeID,
			ApiContactTypeRequestModel request)
		{
			var response = new ApiContactTypeResponseModel();
			response.SetProperties(contactTypeID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiContactTypeRequestModel MapResponseToRequest(
			ApiContactTypeResponseModel response)
		{
			var request = new ApiContactTypeRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiContactTypeRequestModel> CreatePatch(ApiContactTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiContactTypeRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>34ab78fbb8b13baa6b44b65d2f2dcf44</Hash>
</Codenesium>*/