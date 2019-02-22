using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiUnitOfficerModelMapper
	{
		public virtual ApiUnitOfficerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUnitOfficerClientRequestModel request)
		{
			var response = new ApiUnitOfficerClientResponseModel();
			response.SetProperties(id,
			                       request.OfficerId,
			                       request.UnitId);
			return response;
		}

		public virtual ApiUnitOfficerClientRequestModel MapClientResponseToRequest(
			ApiUnitOfficerClientResponseModel response)
		{
			var request = new ApiUnitOfficerClientRequestModel();
			request.SetProperties(
				response.OfficerId,
				response.UnitId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a683684bc80b1d2c1ecb04d1559deda8</Hash>
</Codenesium>*/