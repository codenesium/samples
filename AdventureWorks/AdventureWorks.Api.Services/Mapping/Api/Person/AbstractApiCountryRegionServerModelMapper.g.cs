using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCountryRegionServerModelMapper
	{
		public virtual ApiCountryRegionServerResponseModel MapServerRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionServerRequestModel request)
		{
			var response = new ApiCountryRegionServerResponseModel();
			response.SetProperties(countryRegionCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCountryRegionServerRequestModel MapServerResponseToRequest(
			ApiCountryRegionServerResponseModel response)
		{
			var request = new ApiCountryRegionServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiCountryRegionClientRequestModel MapServerResponseToClientRequest(
			ApiCountryRegionServerResponseModel response)
		{
			var request = new ApiCountryRegionClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCountryRegionServerRequestModel> CreatePatch(ApiCountryRegionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCountryRegionServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>80c163b06be2db6783d2247a53465db8</Hash>
</Codenesium>*/