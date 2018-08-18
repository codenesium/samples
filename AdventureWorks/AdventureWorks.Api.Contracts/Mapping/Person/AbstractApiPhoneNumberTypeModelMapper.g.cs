using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiPhoneNumberTypeModelMapper
	{
		public virtual ApiPhoneNumberTypeResponseModel MapRequestToResponse(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel request)
		{
			var response = new ApiPhoneNumberTypeResponseModel();
			response.SetProperties(phoneNumberTypeID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiPhoneNumberTypeRequestModel MapResponseToRequest(
			ApiPhoneNumberTypeResponseModel response)
		{
			var request = new ApiPhoneNumberTypeRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiPhoneNumberTypeRequestModel> CreatePatch(ApiPhoneNumberTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPhoneNumberTypeRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0c617c0804870312986f01cce4ebb7c2</Hash>
</Codenesium>*/