using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiPasswordServerModelMapper
	{
		public virtual ApiPasswordServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiPasswordServerRequestModel request)
		{
			var response = new ApiPasswordServerResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.PasswordHash,
			                       request.PasswordSalt,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiPasswordServerRequestModel MapServerResponseToRequest(
			ApiPasswordServerResponseModel response)
		{
			var request = new ApiPasswordServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.PasswordHash,
				response.PasswordSalt,
				response.Rowguid);
			return request;
		}

		public virtual ApiPasswordClientRequestModel MapServerResponseToClientRequest(
			ApiPasswordServerResponseModel response)
		{
			var request = new ApiPasswordClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.PasswordHash,
				response.PasswordSalt,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiPasswordServerRequestModel> CreatePatch(ApiPasswordServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPasswordServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.PasswordHash, model.PasswordHash);
			patch.Replace(x => x.PasswordSalt, model.PasswordSalt);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>70aaecd31e4ea688b03c4b7eb227e10e</Hash>
</Codenesium>*/