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
			ApiReplyRequestModel model);

		ApiReplyResponseModel MapBOToModel(
			BOReply boReply);

		List<ApiReplyResponseModel> MapBOToModel(
			List<BOReply> items);
	}
}

/*<Codenesium>
    <Hash>53ae41bcf3c6ce091eb3a6d14fc02fdc</Hash>
</Codenesium>*/