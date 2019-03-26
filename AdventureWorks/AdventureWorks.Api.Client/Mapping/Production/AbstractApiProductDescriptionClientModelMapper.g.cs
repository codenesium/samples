using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductDescriptionModelMapper
	{
		public virtual ApiProductDescriptionClientResponseModel MapClientRequestToResponse(
			int productDescriptionID,
			ApiProductDescriptionClientRequestModel request)
		{
			var response = new ApiProductDescriptionClientResponseModel();
			response.SetProperties(productDescriptionID,
			                       request.Description,
			                       request.ModifiedDate,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductDescriptionClientRequestModel MapClientResponseToRequest(
			ApiProductDescriptionClientResponseModel response)
		{
			var request = new ApiProductDescriptionClientRequestModel();
			request.SetProperties(
				response.Description,
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b2aad6862b2fc4f0698006ae81af94f3</Hash>
</Codenesium>*/