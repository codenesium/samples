using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiPhoneNumberTypeServerModelMapper
	{
		public virtual ApiPhoneNumberTypeServerResponseModel MapServerRequestToResponse(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeServerRequestModel request)
		{
			var response = new ApiPhoneNumberTypeServerResponseModel();
			response.SetProperties(phoneNumberTypeID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiPhoneNumberTypeServerRequestModel MapServerResponseToRequest(
			ApiPhoneNumberTypeServerResponseModel response)
		{
			var request = new ApiPhoneNumberTypeServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiPhoneNumberTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPhoneNumberTypeServerResponseModel response)
		{
			var request = new ApiPhoneNumberTypeClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPhoneNumberTypeServerRequestModel> CreatePatch(ApiPhoneNumberTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPhoneNumberTypeServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>c62f247d055c5de62a4c58127a4e6ac6</Hash>
</Codenesium>*/