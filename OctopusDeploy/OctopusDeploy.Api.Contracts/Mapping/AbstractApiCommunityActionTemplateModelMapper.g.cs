using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiCommunityActionTemplateModelMapper
	{
		public virtual ApiCommunityActionTemplateResponseModel MapRequestToResponse(
			string id,
			ApiCommunityActionTemplateRequestModel request)
		{
			var response = new ApiCommunityActionTemplateResponseModel();
			response.SetProperties(id,
			                       request.ExternalId,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiCommunityActionTemplateRequestModel MapResponseToRequest(
			ApiCommunityActionTemplateResponseModel response)
		{
			var request = new ApiCommunityActionTemplateRequestModel();
			request.SetProperties(
				response.ExternalId,
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCommunityActionTemplateRequestModel> CreatePatch(ApiCommunityActionTemplateRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCommunityActionTemplateRequestModel>();
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>23ddfcecc4cc0fa29f431fb440f70657</Hash>
</Codenesium>*/