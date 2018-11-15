using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiStateProvinceServerModelMapper
	{
		public virtual ApiStateProvinceServerResponseModel MapServerRequestToResponse(
			int stateProvinceID,
			ApiStateProvinceServerRequestModel request)
		{
			var response = new ApiStateProvinceServerResponseModel();
			response.SetProperties(stateProvinceID,
			                       request.CountryRegionCode,
			                       request.IsOnlyStateProvinceFlag,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.StateProvinceCode,
			                       request.TerritoryID);
			return response;
		}

		public virtual ApiStateProvinceServerRequestModel MapServerResponseToRequest(
			ApiStateProvinceServerResponseModel response)
		{
			var request = new ApiStateProvinceServerRequestModel();
			request.SetProperties(
				response.CountryRegionCode,
				response.IsOnlyStateProvinceFlag,
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.StateProvinceCode,
				response.TerritoryID);
			return request;
		}

		public virtual ApiStateProvinceClientRequestModel MapServerResponseToClientRequest(
			ApiStateProvinceServerResponseModel response)
		{
			var request = new ApiStateProvinceClientRequestModel();
			request.SetProperties(
				response.CountryRegionCode,
				response.IsOnlyStateProvinceFlag,
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.StateProvinceCode,
				response.TerritoryID);
			return request;
		}

		public JsonPatchDocument<ApiStateProvinceServerRequestModel> CreatePatch(ApiStateProvinceServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStateProvinceServerRequestModel>();
			patch.Replace(x => x.CountryRegionCode, model.CountryRegionCode);
			patch.Replace(x => x.IsOnlyStateProvinceFlag, model.IsOnlyStateProvinceFlag);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.StateProvinceCode, model.StateProvinceCode);
			patch.Replace(x => x.TerritoryID, model.TerritoryID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9bd34cf7332d73ff5e4171dab045a0f4</Hash>
</Codenesium>*/