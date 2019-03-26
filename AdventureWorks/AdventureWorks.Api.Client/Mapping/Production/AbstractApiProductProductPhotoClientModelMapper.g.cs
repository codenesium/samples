using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductProductPhotoModelMapper
	{
		public virtual ApiProductProductPhotoClientResponseModel MapClientRequestToResponse(
			int productID,
			ApiProductProductPhotoClientRequestModel request)
		{
			var response = new ApiProductProductPhotoClientResponseModel();
			response.SetProperties(productID,
			                       request.ModifiedDate,
			                       request.Primary,
			                       request.ProductPhotoID);
			return response;
		}

		public virtual ApiProductProductPhotoClientRequestModel MapClientResponseToRequest(
			ApiProductProductPhotoClientResponseModel response)
		{
			var request = new ApiProductProductPhotoClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Primary,
				response.ProductPhotoID);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b245e73595cd07e2f3578224898e9b38</Hash>
</Codenesium>*/