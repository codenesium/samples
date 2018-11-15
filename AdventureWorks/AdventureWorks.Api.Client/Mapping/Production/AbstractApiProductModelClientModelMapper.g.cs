using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiProductModelModelMapper
	{
		public virtual ApiProductModelClientResponseModel MapClientRequestToResponse(
			int productModelID,
			ApiProductModelClientRequestModel request)
		{
			var response = new ApiProductModelClientResponseModel();
			response.SetProperties(productModelID,
			                       request.CatalogDescription,
			                       request.Instruction,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiProductModelClientRequestModel MapClientResponseToRequest(
			ApiProductModelClientResponseModel response)
		{
			var request = new ApiProductModelClientRequestModel();
			request.SetProperties(
				response.CatalogDescription,
				response.Instruction,
				response.ModifiedDate,
				response.Name,
				response.Rowguid);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>62f91b966f0fe6002dbc1a6dda2df0ac</Hash>
</Codenesium>*/