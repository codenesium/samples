using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiCommentModelMapper : IApiCommentModelMapper
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
    <Hash>a573c0f07a5d6093257c64b5a477648f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/