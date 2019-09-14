using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IDALReplyMapper
	{
		Reply MapModelToEntity(
			int replyId,
			ApiReplyServerRequestModel model);

		ApiReplyServerResponseModel MapEntityToModel(
			Reply item);

		List<ApiReplyServerResponseModel> MapEntityToModel(
			List<Reply> items);
	}
}

/*<Codenesium>
    <Hash>ab33fb3594ed69588d92b03c491dbdb1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/