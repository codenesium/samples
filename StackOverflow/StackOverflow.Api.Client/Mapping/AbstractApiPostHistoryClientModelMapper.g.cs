using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostHistoryModelMapper
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
    <Hash>7e3cc6d59fa17c6679ea082ae7bc807b</Hash>
</Codenesium>*/