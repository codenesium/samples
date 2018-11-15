using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductCategoryModelMapper
	{
		public virtual ApiProductCategoryClientResponseModel MapClientRequestToResponse(
			int productCategoryID,
			ApiProductCategoryClientRequestModel request)
		{
			var response = new ApiProductCategoryClientResponseModel();
			response.SetProperties(productCategoryID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductCategoryClientRequestModel MapClientResponseToRequest(
			ApiProductCategoryClientResponseModel response)
		{
			var request = new ApiProductCategoryClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5390e5804305c5782800a0f59bf621bb</Hash>
</Codenesium>*/