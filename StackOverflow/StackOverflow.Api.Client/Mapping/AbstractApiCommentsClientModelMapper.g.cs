using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiCommentsModelMapper
	{
		public virtual ApiCommentsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCommentsClientRequestModel request)
		{
			var response = new ApiCommentsClientResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.PostId,
			                       request.Score,
			                       request.Text,
			                       request.UserId);
			return response;
		}

		public virtual ApiCommentsClientRequestModel MapClientResponseToRequest(
			ApiCommentsClientResponseModel response)
		{
			var request = new ApiCommentsClientRequestModel();
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
    <Hash>1c58d2808a6d7075fd680c2937452869</Hash>
</Codenesium>*/