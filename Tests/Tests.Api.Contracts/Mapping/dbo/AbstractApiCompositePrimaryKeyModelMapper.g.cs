using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiCompositePrimaryKeyModelMapper
	{
		public virtual ApiCompositePrimaryKeyResponseModel MapRequestToResponse(
			int id,
			ApiCompositePrimaryKeyRequestModel request)
		{
			var response = new ApiCompositePrimaryKeyResponseModel();
			response.SetProperties(id,
			                       request.Id2);
			return response;
		}

		public virtual ApiCompositePrimaryKeyRequestModel MapResponseToRequest(
			ApiCompositePrimaryKeyResponseModel response)
		{
			var request = new ApiCompositePrimaryKeyRequestModel();
			request.SetProperties(
				response.Id2);
			return request;
		}

		public JsonPatchDocument<ApiCompositePrimaryKeyRequestModel> CreatePatch(ApiCompositePrimaryKeyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCompositePrimaryKeyRequestModel>();
			patch.Replace(x => x.Id2, model.Id2);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8c11632b26c86dae1547b92096414658</Hash>
</Codenesium>*/