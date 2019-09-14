using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiEmployeeModelMapper : IApiEmployeeModelMapper
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
    <Hash>ef9915cd394ec166a428c0f3561d95cf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/