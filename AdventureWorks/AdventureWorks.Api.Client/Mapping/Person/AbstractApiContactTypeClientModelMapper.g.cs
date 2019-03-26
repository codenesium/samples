using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiContactTypeModelMapper
	{
		public virtual ApiContactTypeClientResponseModel MapClientRequestToResponse(
			int contactTypeID,
			ApiContactTypeClientRequestModel request)
		{
			var response = new ApiContactTypeClientResponseModel();
			response.SetProperties(contactTypeID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiContactTypeClientRequestModel MapClientResponseToRequest(
			ApiContactTypeClientResponseModel response)
		{
			var request = new ApiContactTypeClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>780555c79da9e8fe7cb7695c41338b0a</Hash>
</Codenesium>*/