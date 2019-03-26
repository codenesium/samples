using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiCommentModelMapper
	{
		ApiCommentClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCommentClientRequestModel request);

		ApiCommentClientRequestModel MapClientResponseToRequest(
			ApiCommentClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>f62eab68fb626181db22b8ace46bb9d4</Hash>
</Codenesium>*/