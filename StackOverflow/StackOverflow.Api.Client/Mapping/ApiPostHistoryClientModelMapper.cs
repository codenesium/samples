using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiPostHistoryModelMapper : IApiPostHistoryModelMapper
	{
		public virtual ApiPostHistoryClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostHistoryClientRequestModel request)
		{
			var response = new ApiPostHistoryClientResponseModel();
			response.SetProperties(id,
			                       request.Comment,
			                       request.CreationDate,
			                       request.PostHistoryTypeId,
			                       request.PostId,
			                       request.RevisionGUID,
			                       request.Text,
			                       request.UserDisplayName,
			                       request.UserId);
			return response;
		}

		public virtual ApiPostHistoryClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryClientResponseModel response)
		{
			var request = new ApiPostHistoryClientRequestModel();
			request.SetProperties(
				response.Comment,
				response.CreationDate,
				response.PostHistoryTypeId,
				response.PostId,
				response.RevisionGUID,
				response.Text,
				response.UserDisplayName,
				response.UserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c3833a4a7fd0570b406c69d7c0f30a07</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/