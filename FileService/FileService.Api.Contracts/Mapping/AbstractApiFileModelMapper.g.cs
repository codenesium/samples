using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public abstract class AbstractApiFileModelMapper
	{
		public virtual ApiFileResponseModel MapRequestToResponse(
			int id,
			ApiFileRequestModel request)
		{
			var response = new ApiFileResponseModel();
			response.SetProperties(id,
			                       request.BucketId,
			                       request.DateCreated,
			                       request.Description,
			                       request.Expiration,
			                       request.Extension,
			                       request.ExternalId,
			                       request.FileSizeInByte,
			                       request.FileTypeId,
			                       request.Location,
			                       request.PrivateKey,
			                       request.PublicKey);
			return response;
		}

		public virtual ApiFileRequestModel MapResponseToRequest(
			ApiFileResponseModel response)
		{
			var request = new ApiFileRequestModel();
			request.SetProperties(
				response.BucketId,
				response.DateCreated,
				response.Description,
				response.Expiration,
				response.Extension,
				response.ExternalId,
				response.FileSizeInByte,
				response.FileTypeId,
				response.Location,
				response.PrivateKey,
				response.PublicKey);
			return request;
		}

		public JsonPatchDocument<ApiFileRequestModel> CreatePatch(ApiFileRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFileRequestModel>();
			patch.Replace(x => x.BucketId, model.BucketId);
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.Expiration, model.Expiration);
			patch.Replace(x => x.Extension, model.Extension);
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.FileSizeInByte, model.FileSizeInByte);
			patch.Replace(x => x.FileTypeId, model.FileTypeId);
			patch.Replace(x => x.Location, model.Location);
			patch.Replace(x => x.PrivateKey, model.PrivateKey);
			patch.Replace(x => x.PublicKey, model.PublicKey);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b2bf3ad3801890e23449cf4600f894f7</Hash>
</Codenesium>*/