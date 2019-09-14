using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public class ApiFileModelMapper : IApiFileModelMapper
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
    <Hash>a7bb16747dbfcd64470bb33be86b953b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/