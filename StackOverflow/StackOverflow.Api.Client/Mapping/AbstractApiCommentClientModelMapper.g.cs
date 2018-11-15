using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiCommentModelMapper
	{
		public virtual ApiCommentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCommentClientRequestModel request)
		{
			var response = new ApiCommentClientResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.PostId,
			                       request.Score,
			                       request.Text,
			                       request.UserId);
			return response;
		}

		public virtual ApiCommentClientRequestModel MapClientResponseToRequest(
			ApiCommentClientResponseModel response)
		{
			var request = new ApiCommentClientRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.PostId,
				response.Score,
				response.Text,
				response.UserId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>581fc8487710120407d29aaa88bf5fc8</Hash>
</Codenesium>*/