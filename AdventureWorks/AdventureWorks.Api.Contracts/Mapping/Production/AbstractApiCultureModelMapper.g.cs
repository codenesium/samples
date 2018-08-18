using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCultureModelMapper
	{
		public virtual ApiCultureResponseModel MapRequestToResponse(
			string cultureID,
			ApiCultureRequestModel request)
		{
			var response = new ApiCultureResponseModel();
			response.SetProperties(cultureID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCultureRequestModel MapResponseToRequest(
			ApiCultureResponseModel response)
		{
			var request = new ApiCultureRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCultureRequestModel> CreatePatch(ApiCultureRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCultureRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b70ec9f3164e2881f0b76aab65042be9</Hash>
</Codenesium>*/