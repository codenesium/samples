using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductSubcategoryModelMapper
	{
		public virtual ApiProductSubcategoryClientResponseModel MapClientRequestToResponse(
			int productSubcategoryID,
			ApiProductSubcategoryClientRequestModel request)
		{
			var response = new ApiProductSubcategoryClientResponseModel();
			response.SetProperties(productSubcategoryID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.ProductCategoryID,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductSubcategoryClientRequestModel MapClientResponseToRequest(
			ApiProductSubcategoryClientResponseModel response)
		{
			var request = new ApiProductSubcategoryClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.ProductCategoryID,
				response.Rowguid);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5dc99597ec6cca174df67f8452fbc111</Hash>
</Codenesium>*/