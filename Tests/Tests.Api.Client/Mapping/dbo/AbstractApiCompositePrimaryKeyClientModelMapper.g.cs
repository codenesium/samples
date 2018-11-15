using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiCompositePrimaryKeyModelMapper
	{
		public virtual ApiCompositePrimaryKeyClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCompositePrimaryKeyClientRequestModel request)
		{
			var response = new ApiCompositePrimaryKeyClientResponseModel();
			response.SetProperties(id,
			                       request.Id2);
			return response;
		}

		public virtual ApiCompositePrimaryKeyClientRequestModel MapClientResponseToRequest(
			ApiCompositePrimaryKeyClientResponseModel response)
		{
			var request = new ApiCompositePrimaryKeyClientRequestModel();
			request.SetProperties(
				response.Id2);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ce87b809cf0d085867be71de32540afc</Hash>
</Codenesium>*/