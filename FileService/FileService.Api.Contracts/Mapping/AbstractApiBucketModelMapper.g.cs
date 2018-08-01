using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public abstract class AbstractApiBucketModelMapper
	{
		public virtual ApiBucketResponseModel MapRequestToResponse(
			int id,
			ApiBucketRequestModel request)
		{
			var response = new ApiBucketResponseModel();
			response.SetProperties(id,
			                       request.ExternalId,
			                       request.Name);
			return response;
		}

		public virtual ApiBucketRequestModel MapResponseToRequest(
			ApiBucketResponseModel response)
		{
			var request = new ApiBucketRequestModel();
			request.SetProperties(
				response.ExternalId,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiBucketRequestModel> CreatePatch(ApiBucketRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBucketRequestModel>();
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1b4443e90aba4694d2c2c247e584051e</Hash>
</Codenesium>*/