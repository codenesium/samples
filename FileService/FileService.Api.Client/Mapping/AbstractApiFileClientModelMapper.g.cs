using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public abstract class AbstractApiFileModelMapper
	{
		public virtual ApiFileClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFileClientRequestModel request)
		{
			var response = new ApiFileClientResponseModel();
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

		public virtual ApiFileClientRequestModel MapClientResponseToRequest(
			ApiFileClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>f01f88a4b14da767e1824a9aaf4bbc2e</Hash>
</Codenesium>*/