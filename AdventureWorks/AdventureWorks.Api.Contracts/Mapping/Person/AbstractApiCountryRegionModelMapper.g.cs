using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiCountryRegionModelMapper
	{
		public virtual ApiCountryRegionResponseModel MapRequestToResponse(
			string countryRegionCode,
			ApiCountryRegionRequestModel request)
		{
			var response = new ApiCountryRegionResponseModel();
			response.SetProperties(countryRegionCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCountryRegionRequestModel MapResponseToRequest(
			ApiCountryRegionResponseModel response)
		{
			var request = new ApiCountryRegionRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCountryRegionRequestModel> CreatePatch(ApiCountryRegionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCountryRegionRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3dcd41c09a7cf7d7cab6653a4c46bb58</Hash>
</Codenesium>*/