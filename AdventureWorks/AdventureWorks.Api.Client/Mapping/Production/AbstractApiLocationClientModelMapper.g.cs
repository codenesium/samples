using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiLocationModelMapper
	{
		public virtual ApiLocationClientResponseModel MapClientRequestToResponse(
			short locationID,
			ApiLocationClientRequestModel request)
		{
			var response = new ApiLocationClientResponseModel();
			response.SetProperties(locationID,
			                       request.Availability,
			                       request.CostRate,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiLocationClientRequestModel MapClientResponseToRequest(
			ApiLocationClientResponseModel response)
		{
			var request = new ApiLocationClientRequestModel();
			request.SetProperties(
				response.Availability,
				response.CostRate,
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>42a6682b184095dd4ae094a41018b2a3</Hash>
</Codenesium>*/