using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiPersonTypeModelMapper : IApiPersonTypeModelMapper
	{
		public virtual ApiPersonTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonTypeClientRequestModel request)
		{
			var response = new ApiPersonTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiPersonTypeClientRequestModel MapClientResponseToRequest(
			ApiPersonTypeClientResponseModel response)
		{
			var request = new ApiPersonTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>cd5560930b3f6efaf2fdc25101de359f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/