using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiUnitOfficerModelMapper : IApiUnitOfficerModelMapper
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
    <Hash>39b30d27078456c5bdef0aabe56f9a22</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/