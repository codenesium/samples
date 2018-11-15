using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
{
	public abstract class AbstractApiPaymentTypeModelMapper
	{
		public virtual ApiPaymentTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPaymentTypeClientRequestModel request)
		{
			var response = new ApiPaymentTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPaymentTypeClientRequestModel MapClientResponseToRequest(
			ApiPaymentTypeClientResponseModel response)
		{
			var request = new ApiPaymentTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>df8708525eebd4135e1fa2bcfa8b5d7c</Hash>
</Codenesium>*/