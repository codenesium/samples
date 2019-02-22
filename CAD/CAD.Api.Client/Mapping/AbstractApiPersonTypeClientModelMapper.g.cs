using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiPersonTypeModelMapper
	{
		public virtual ApiPersonTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonTypeClientRequestModel request)
		{
			var response = new ApiPersonTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPersonTypeClientRequestModel MapClientResponseToRequest(
			ApiPersonTypeClientResponseModel response)
		{
			var request = new ApiPersonTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>eaf33bdbe1b539c9212400195e3568e0</Hash>
</Codenesium>*/