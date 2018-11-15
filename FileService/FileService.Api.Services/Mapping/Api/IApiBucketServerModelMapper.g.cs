using FileServiceNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiBucketServerModelMapper
	{
		ApiBucketServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBucketServerRequestModel request);

		ApiBucketServerRequestModel MapServerResponseToRequest(
			ApiBucketServerResponseModel response);

		ApiBucketClientRequestModel MapServerResponseToClientRequest(
			ApiBucketServerResponseModel response);

		JsonPatchDocument<ApiBucketServerRequestModel> CreatePatch(ApiBucketServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4fa8ccfa59570eb981649e54f564d487</Hash>
</Codenesium>*/