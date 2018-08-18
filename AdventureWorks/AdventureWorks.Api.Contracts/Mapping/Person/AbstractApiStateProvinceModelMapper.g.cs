using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiStateProvinceModelMapper
	{
		public virtual ApiStateProvinceResponseModel MapRequestToResponse(
			int stateProvinceID,
			ApiStateProvinceRequestModel request)
		{
			var response = new ApiStateProvinceResponseModel();
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

		public virtual ApiStateProvinceRequestModel MapResponseToRequest(
			ApiStateProvinceResponseModel response)
		{
			var request = new ApiStateProvinceRequestModel();
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

		public JsonPatchDocument<ApiStateProvinceRequestModel> CreatePatch(ApiStateProvinceRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStateProvinceRequestModel>();
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
    <Hash>8eb273f0b822f9379d0eadc919175025</Hash>
</Codenesium>*/