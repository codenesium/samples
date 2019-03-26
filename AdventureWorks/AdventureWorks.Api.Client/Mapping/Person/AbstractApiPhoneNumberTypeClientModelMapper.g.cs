using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiPhoneNumberTypeModelMapper
	{
		public virtual ApiPhoneNumberTypeClientResponseModel MapClientRequestToResponse(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeClientRequestModel request)
		{
			var response = new ApiPhoneNumberTypeClientResponseModel();
			response.SetProperties(phoneNumberTypeID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiPhoneNumberTypeClientRequestModel MapClientResponseToRequest(
			ApiPhoneNumberTypeClientResponseModel response)
		{
			var request = new ApiPhoneNumberTypeClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>cf4a3dac06653ea389b34458e8e45277</Hash>
</Codenesium>*/