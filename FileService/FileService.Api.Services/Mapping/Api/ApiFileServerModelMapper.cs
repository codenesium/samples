using FileServiceNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class ApiFileServerModelMapper : IApiFileServerModelMapper
	{
		public virtual ApiFileServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFileServerRequestModel request)
		{
			var response = new ApiFileServerResponseModel();
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

		public virtual ApiFileServerRequestModel MapServerResponseToRequest(
			ApiFileServerResponseModel response)
		{
			var request = new ApiFileServerRequestModel();
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

		public virtual ApiFileClientRequestModel MapServerResponseToClientRequest(
			ApiFileServerResponseModel response)
		{
			var request = new ApiFileClientRequestModel();
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

		public JsonPatchDocument<ApiFileServerRequestModel> CreatePatch(ApiFileServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFileServerRequestModel>();
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
    <Hash>834d6accd1530f36989d66ce124aeda3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/