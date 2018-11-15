using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public abstract class AbstractApiBucketModelMapper
	{
		public virtual ApiBucketClientResponseModel MapClientRequestToResponse(
			int id,
			ApiBucketClientRequestModel request)
		{
			var response = new ApiBucketClientResponseModel();
			response.SetProperties(id,
			                       request.ExternalId,
			                       request.Name);
			return response;
		}

		public virtual ApiBucketClientRequestModel MapClientResponseToRequest(
			ApiBucketClientResponseModel response)
		{
			var request = new ApiBucketClientRequestModel();
			request.SetProperties(
				response.ExternalId,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f6451d3993cebef1d769e5676a1dbc51</Hash>
</Codenesium>*/