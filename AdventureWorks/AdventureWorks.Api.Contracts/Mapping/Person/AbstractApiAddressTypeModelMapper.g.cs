using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiAddressTypeModelMapper
	{
		public virtual ApiAddressTypeResponseModel MapRequestToResponse(
			int addressTypeID,
			ApiAddressTypeRequestModel request)
		{
			var response = new ApiAddressTypeResponseModel();
			response.SetProperties(addressTypeID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiAddressTypeRequestModel MapResponseToRequest(
			ApiAddressTypeResponseModel response)
		{
			var request = new ApiAddressTypeRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiAddressTypeRequestModel> CreatePatch(ApiAddressTypeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAddressTypeRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>6c50679a298e6364a73fe617e316ed48</Hash>
</Codenesium>*/