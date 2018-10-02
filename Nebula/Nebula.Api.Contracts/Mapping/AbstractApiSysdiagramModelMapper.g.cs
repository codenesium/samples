using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
	public abstract class AbstractApiSysdiagramModelMapper
	{
		public virtual ApiSysdiagramResponseModel MapRequestToResponse(
			int diagramId,
			ApiSysdiagramRequestModel request)
		{
			var response = new ApiSysdiagramResponseModel();
			response.SetProperties(diagramId,
			                       request.Definition,
			                       request.Name,
			                       request.PrincipalId,
			                       request.Version);
			return response;
		}

		public virtual ApiSysdiagramRequestModel MapResponseToRequest(
			ApiSysdiagramResponseModel response)
		{
			var request = new ApiSysdiagramRequestModel();
			request.SetProperties(
				response.Definition,
				response.Name,
				response.PrincipalId,
				response.Version);
			return request;
		}

		public JsonPatchDocument<ApiSysdiagramRequestModel> CreatePatch(ApiSysdiagramRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSysdiagramRequestModel>();
			patch.Replace(x => x.Definition, model.Definition);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.PrincipalId, model.PrincipalId);
			patch.Replace(x => x.Version, model.Version);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>af3a014e58ab45e152a04a1dcf6ef3fd</Hash>
</Codenesium>*/