using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiCultureModelMapper
	{
		public virtual ApiCultureClientResponseModel MapClientRequestToResponse(
			string cultureID,
			ApiCultureClientRequestModel request)
		{
			var response = new ApiCultureClientResponseModel();
			response.SetProperties(cultureID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiCultureClientRequestModel MapClientResponseToRequest(
			ApiCultureClientResponseModel response)
		{
			var request = new ApiCultureClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d3d01c139a17e7c30f5eb8e1f782ed72</Hash>
</Codenesium>*/