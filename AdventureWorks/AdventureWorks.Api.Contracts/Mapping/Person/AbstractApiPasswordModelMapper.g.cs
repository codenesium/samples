using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiPasswordModelMapper
	{
		public virtual ApiPasswordResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPasswordRequestModel request)
		{
			var response = new ApiPasswordResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.PasswordHash,
			                       request.PasswordSalt,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiPasswordRequestModel MapResponseToRequest(
			ApiPasswordResponseModel response)
		{
			var request = new ApiPasswordRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.PasswordHash,
				response.PasswordSalt,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiPasswordRequestModel> CreatePatch(ApiPasswordRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPasswordRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.PasswordHash, model.PasswordHash);
			patch.Replace(x => x.PasswordSalt, model.PasswordSalt);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>491905d63af1c6d6e06a1cca5bdbf376</Hash>
</Codenesium>*/