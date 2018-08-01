using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiFeedModelMapper
	{
		public virtual ApiFeedResponseModel MapRequestToResponse(
			string id,
			ApiFeedRequestModel request)
		{
			var response = new ApiFeedResponseModel();
			response.SetProperties(id,
			                       request.FeedType,
			                       request.FeedUri,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiFeedRequestModel MapResponseToRequest(
			ApiFeedResponseModel response)
		{
			var request = new ApiFeedRequestModel();
			request.SetProperties(
				response.FeedType,
				response.FeedUri,
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiFeedRequestModel> CreatePatch(ApiFeedRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFeedRequestModel>();
			patch.Replace(x => x.FeedType, model.FeedType);
			patch.Replace(x => x.FeedUri, model.FeedUri);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>910f913829f6d8b568e52fa006e44339</Hash>
</Codenesium>*/