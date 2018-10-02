using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiTenantModelMapper
	{
		public virtual ApiTenantResponseModel MapRequestToResponse(
			int id,
			ApiTenantRequestModel request)
		{
			var response = new ApiTenantResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTenantRequestModel MapResponseToRequest(
			ApiTenantResponseModel response)
		{
			var request = new ApiTenantRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTenantRequestModel> CreatePatch(ApiTenantRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTenantRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c73759a7b1474540160265a492fb33f4</Hash>
</Codenesium>*/