using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiAddressModelMapper
	{
		public virtual ApiAddressResponseModel MapRequestToResponse(
			int addressID,
			ApiAddressRequestModel request)
		{
			var response = new ApiAddressResponseModel();
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

		public virtual ApiAddressRequestModel MapResponseToRequest(
			ApiAddressResponseModel response)
		{
			var request = new ApiAddressRequestModel();
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

		public JsonPatchDocument<ApiAddressRequestModel> CreatePatch(ApiAddressRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAddressRequestModel>();
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
    <Hash>57eb6960baabb613e84ea5ba4d182bbf</Hash>
</Codenesium>*/