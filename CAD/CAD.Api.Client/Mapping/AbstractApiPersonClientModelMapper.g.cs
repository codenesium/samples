using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiPersonModelMapper
	{
		public virtual ApiPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonClientRequestModel request)
		{
			var response = new ApiPersonClientResponseModel();
			response.SetProperties(id,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.Ssn);
			return response;
		}

		public virtual ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.FirstName,
				response.LastName,
				response.Phone,
				response.Ssn);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>370c06cb2cfdf91faf0650a32fecd11d</Hash>
</Codenesium>*/