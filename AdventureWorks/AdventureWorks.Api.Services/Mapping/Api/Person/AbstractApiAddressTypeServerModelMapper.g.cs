using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiAddressTypeServerModelMapper
	{
		public virtual ApiAddressTypeServerResponseModel MapServerRequestToResponse(
			int addressTypeID,
			ApiAddressTypeServerRequestModel request)
		{
			var response = new ApiAddressTypeServerResponseModel();
			response.SetProperties(addressTypeID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiAddressTypeServerRequestModel MapServerResponseToRequest(
			ApiAddressTypeServerResponseModel response)
		{
			var request = new ApiAddressTypeServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public virtual ApiAddressTypeClientRequestModel MapServerResponseToClientRequest(
			ApiAddressTypeServerResponseModel response)
		{
			var request = new ApiAddressTypeClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiAddressTypeServerRequestModel> CreatePatch(ApiAddressTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAddressTypeServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3ddf3e107349e7b6b848d78c68edabfe</Hash>
</Codenesium>*/