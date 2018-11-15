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
    <Hash>c7076b25ef95ca231fa8bfcf362fb2f4</Hash>
</Codenesium>*/