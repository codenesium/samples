using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiAddressServerModelMapper
	{
		public virtual ApiAddressServerResponseModel MapServerRequestToResponse(
			int addressID,
			ApiAddressServerRequestModel request)
		{
			var response = new ApiAddressServerResponseModel();
			response.SetProperties(addressID,
			                       request.AddressLine1,
			                       request.AddressLine2,
			                       request.City,
			                       request.ModifiedDate,
			                       request.PostalCode,
			                       request.Rowguid,
			                       request.StateProvinceID);
			return response;
		}

		public virtual ApiAddressServerRequestModel MapServerResponseToRequest(
			ApiAddressServerResponseModel response)
		{
			var request = new ApiAddressServerRequestModel();
			request.SetProperties(
				response.AddressLine1,
				response.AddressLine2,
				response.City,
				response.ModifiedDate,
				response.PostalCode,
				response.Rowguid,
				response.StateProvinceID);
			return request;
		}

		public virtual ApiAddressClientRequestModel MapServerResponseToClientRequest(
			ApiAddressServerResponseModel response)
		{
			var request = new ApiAddressClientRequestModel();
			request.SetProperties(
				response.AddressLine1,
				response.AddressLine2,
				response.City,
				response.ModifiedDate,
				response.PostalCode,
				response.Rowguid,
				response.StateProvinceID);
			return request;
		}

		public JsonPatchDocument<ApiAddressServerRequestModel> CreatePatch(ApiAddressServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAddressServerRequestModel>();
			patch.Replace(x => x.AddressLine1, model.AddressLine1);
			patch.Replace(x => x.AddressLine2, model.AddressLine2);
			patch.Replace(x => x.City, model.City);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.PostalCode, model.PostalCode);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.StateProvinceID, model.StateProvinceID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>15f5d32e9c5a19dc0717ec8ae0caaffe</Hash>
</Codenesium>*/