using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiStoreModelMapper
	{
		public virtual ApiStoreClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiStoreClientRequestModel request)
		{
			var response = new ApiStoreClientResponseModel();
			response.SetProperties(businessEntityID,
			                       request.Demographic,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.SalesPersonID);
			return response;
		}

		public virtual ApiStoreClientRequestModel MapClientResponseToRequest(
			ApiStoreClientResponseModel response)
		{
			var request = new ApiStoreClientRequestModel();
			request.SetProperties(
				response.Demographic,
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.SalesPersonID);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>2aced9517c16a521b1cca529d6579e8d</Hash>
</Codenesium>*/