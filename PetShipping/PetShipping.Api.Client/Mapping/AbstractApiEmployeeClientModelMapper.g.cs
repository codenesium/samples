using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiEmployeeModelMapper
	{
		public virtual ApiEmployeeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEmployeeClientRequestModel request)
		{
			var response = new ApiEmployeeClientResponseModel();
			response.SetProperties(id,
			                       request.FirstName,
			                       request.IsSalesPerson,
			                       request.IsShipper,
			                       request.LastName);
			return response;
		}

		public virtual ApiEmployeeClientRequestModel MapClientResponseToRequest(
			ApiEmployeeClientResponseModel response)
		{
			var request = new ApiEmployeeClientRequestModel();
			request.SetProperties(
				response.FirstName,
				response.IsSalesPerson,
				response.IsShipper,
				response.LastName);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>439041400d0d4754463fc2de68e3dacd</Hash>
</Codenesium>*/