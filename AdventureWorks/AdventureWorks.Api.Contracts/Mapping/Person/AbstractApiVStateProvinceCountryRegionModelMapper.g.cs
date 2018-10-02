using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiVStateProvinceCountryRegionModelMapper
	{
		public virtual ApiVStateProvinceCountryRegionResponseModel MapRequestToResponse(
			int stateProvinceID,
			ApiVStateProvinceCountryRegionRequestModel request)
		{
			var response = new ApiVStateProvinceCountryRegionResponseModel();
			response.SetProperties(stateProvinceID,
			                       request.CountryRegionCode,
			                       request.CountryRegionName,
			                       request.IsOnlyStateProvinceFlag,
			                       request.StateProvinceCode,
			                       request.StateProvinceName,
			                       request.TerritoryID);
			return response;
		}

		public virtual ApiVStateProvinceCountryRegionRequestModel MapResponseToRequest(
			ApiVStateProvinceCountryRegionResponseModel response)
		{
			var request = new ApiVStateProvinceCountryRegionRequestModel();
			request.SetProperties(
				response.CountryRegionCode,
				response.CountryRegionName,
				response.IsOnlyStateProvinceFlag,
				response.StateProvinceCode,
				response.StateProvinceName,
				response.TerritoryID);
			return request;
		}

		public JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel> CreatePatch(ApiVStateProvinceCountryRegionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel>();
			patch.Replace(x => x.CountryRegionCode, model.CountryRegionCode);
			patch.Replace(x => x.CountryRegionName, model.CountryRegionName);
			patch.Replace(x => x.IsOnlyStateProvinceFlag, model.IsOnlyStateProvinceFlag);
			patch.Replace(x => x.StateProvinceCode, model.StateProvinceCode);
			patch.Replace(x => x.StateProvinceName, model.StateProvinceName);
			patch.Replace(x => x.TerritoryID, model.TerritoryID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>888d7295ddb44c7564c343834326d6dd</Hash>
</Codenesium>*/