using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLCommentMapper
	{
		BOComment MapModelToBO(
			int id,
			ApiCommentServerRequestModel model);

		ApiCommentServerResponseModel MapBOToModel(
			BOComment boComment);

		List<ApiCommentServerResponseModel> MapBOToModel(
			List<BOComment> items);
	}
}

/*<Codenesium>
    <Hash>e1190a5062cfb01cd78314f85ddae7c2</Hash>
</Codenesium>*/