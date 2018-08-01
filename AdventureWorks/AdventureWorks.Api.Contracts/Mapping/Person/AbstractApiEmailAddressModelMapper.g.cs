using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiEmailAddressModelMapper
	{
		public virtual ApiEmailAddressResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmailAddressRequestModel request)
		{
			var response = new ApiEmailAddressResponseModel();
			response.SetProperties(businessEntityID,
			                       request.EmailAddress1,
			                       request.EmailAddressID,
			                       request.ModifiedDate,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiEmailAddressRequestModel MapResponseToRequest(
			ApiEmailAddressResponseModel response)
		{
			var request = new ApiEmailAddressRequestModel();
			request.SetProperties(
				response.EmailAddress1,
				response.EmailAddressID,
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiEmailAddressRequestModel> CreatePatch(ApiEmailAddressRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEmailAddressRequestModel>();
			patch.Replace(x => x.EmailAddress1, model.EmailAddress1);
			patch.Replace(x => x.EmailAddressID, model.EmailAddressID);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a536ac99fcf0bf63ad6f2723545e739d</Hash>
</Codenesium>*/