using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public class ApiFileTypeModelMapper : IApiFileTypeModelMapper
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
    <Hash>624c146ef174ed549feb58a7b4d73f5d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/