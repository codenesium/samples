using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiBusinessEntityModelMapper
	{
		public virtual ApiBusinessEntityClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityClientRequestModel request)
		{
			var response = new ApiBusinessEntityClientResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiBusinessEntityClientRequestModel MapClientResponseToRequest(
			ApiBusinessEntityClientResponseModel response)
		{
			var request = new ApiBusinessEntityClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>7345583127be55ca2a6986f874a802c2</Hash>
</Codenesium>*/