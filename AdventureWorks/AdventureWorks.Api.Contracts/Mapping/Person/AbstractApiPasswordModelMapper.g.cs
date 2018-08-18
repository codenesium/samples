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
    <Hash>44eafc6ba65060599d8d7f479db4670e</Hash>
</Codenesium>*/