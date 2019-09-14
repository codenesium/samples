using FileServiceNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class ApiBucketServerModelMapper : IApiBucketServerModelMapper
	{
		public virtual ApiBucketServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBucketServerRequestModel request)
		{
			var response = new ApiBucketServerResponseModel();
			response.SetProperties(id,
			                       request.ExternalId,
			                       request.Name);
			return response;
		}

		public virtual ApiBucketServerRequestModel MapServerResponseToRequest(
			ApiBucketServerResponseModel response)
		{
			var request = new ApiBucketServerRequestModel();
			request.SetProperties(
				response.ExternalId,
				response.Name);
			return request;
		}

		public virtual ApiBucketClientRequestModel MapServerResponseToClientRequest(
			ApiBucketServerResponseModel response)
		{
			var request = new ApiBucketClientRequestModel();
			request.SetProperties(
				response.ExternalId,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiBucketServerRequestModel> CreatePatch(ApiBucketServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBucketServerRequestModel>();
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>bce520663c4c679695b337c73e7379ce</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/