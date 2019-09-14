using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public class ApiBucketModelMapper : IApiBucketModelMapper
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
    <Hash>6ae707dc2153fade587fa742e0e7e81b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/