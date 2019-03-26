using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiStateProvinceModelMapper
	{
		public virtual ApiStateProvinceClientResponseModel MapClientRequestToResponse(
			int stateProvinceID,
			ApiStateProvinceClientRequestModel request)
		{
			var response = new ApiStateProvinceClientResponseModel();
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

		public virtual ApiStateProvinceClientRequestModel MapClientResponseToRequest(
			ApiStateProvinceClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>242b3d0248fa61b15cc0251f9c1b2bc4</Hash>
</Codenesium>*/