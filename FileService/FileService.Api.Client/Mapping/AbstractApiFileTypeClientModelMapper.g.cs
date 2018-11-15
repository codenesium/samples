using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public abstract class AbstractApiFileTypeModelMapper
	{
		public virtual ApiFileTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFileTypeClientRequestModel request)
		{
			var response = new ApiFileTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiFileTypeClientRequestModel MapClientResponseToRequest(
			ApiFileTypeClientResponseModel response)
		{
			var request = new ApiFileTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b01ee01b16716a399be76ce6f7378f5e</Hash>
</Codenesium>*/