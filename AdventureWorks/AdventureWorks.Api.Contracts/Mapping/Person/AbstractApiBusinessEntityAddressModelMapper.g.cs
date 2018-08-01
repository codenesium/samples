using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiBusinessEntityAddressModelMapper
	{
		public virtual ApiBusinessEntityAddressResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel request)
		{
			var response = new ApiBusinessEntityAddressResponseModel();
			response.SetProperties(businessEntityID,
			                       request.AddressID,
			                       request.AddressTypeID,
			                       request.ModifiedDate,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiBusinessEntityAddressRequestModel MapResponseToRequest(
			ApiBusinessEntityAddressResponseModel response)
		{
			var request = new ApiBusinessEntityAddressRequestModel();
			request.SetProperties(
				response.AddressID,
				response.AddressTypeID,
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiBusinessEntityAddressRequestModel> CreatePatch(ApiBusinessEntityAddressRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBusinessEntityAddressRequestModel>();
			patch.Replace(x => x.AddressID, model.AddressID);
			patch.Replace(x => x.AddressTypeID, model.AddressTypeID);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ac26fe9f115f88cd098d3915e0b49c8c</Hash>
</Codenesium>*/