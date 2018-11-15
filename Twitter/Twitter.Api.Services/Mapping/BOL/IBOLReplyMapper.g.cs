using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IBOLReplyMapper
	{
		BOReply MapModelToBO(
			int replyId,
			ApiReplyServerRequestModel model);

		ApiReplyServerResponseModel MapBOToModel(
			BOReply boReply);

		List<ApiReplyServerResponseModel> MapBOToModel(
			List<BOReply> items);
	}
}

/*<Codenesium>
    <Hash>81663376a97821b4014aef4444d64207</Hash>
</Codenesium>*/