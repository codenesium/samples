using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public abstract class AbstractApiProvinceModelMapper
	{
		public virtual ApiProvinceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiProvinceClientRequestModel request)
		{
			var response = new ApiProvinceClientResponseModel();
			response.SetProperties(id,
			                       request.CountryId,
			                       request.Name);
			return response;
		}

		public virtual ApiProvinceClientRequestModel MapClientResponseToRequest(
			ApiProvinceClientResponseModel response)
		{
			var request = new ApiProvinceClientRequestModel();
			request.SetProperties(
				response.CountryId,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d32f1889c7903dd1699ff474660f7909</Hash>
</Codenesium>*/