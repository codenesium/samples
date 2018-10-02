using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiIncludedColumnTestModelMapper
	{
		public virtual ApiIncludedColumnTestResponseModel MapRequestToResponse(
			int id,
			ApiIncludedColumnTestRequestModel request)
		{
			var response = new ApiIncludedColumnTestResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.Name2);
			return response;
		}

		public virtual ApiIncludedColumnTestRequestModel MapResponseToRequest(
			ApiIncludedColumnTestResponseModel response)
		{
			var request = new ApiIncludedColumnTestRequestModel();
			request.SetProperties(
				response.Name,
				response.Name2);
			return request;
		}

		public JsonPatchDocument<ApiIncludedColumnTestRequestModel> CreatePatch(ApiIncludedColumnTestRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiIncludedColumnTestRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Name2, model.Name2);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ac4b1fefb09ad4e5ec43af4f98964342</Hash>
</Codenesium>*/