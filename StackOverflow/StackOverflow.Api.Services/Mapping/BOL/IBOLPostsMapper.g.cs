using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostsMapper
	{
		BOPosts MapModelToBO(
			int id,
			ApiPostsRequestModel model);

		ApiPostsResponseModel MapBOToModel(
			BOPosts boPosts);

		List<ApiPostsResponseModel> MapBOToModel(
			List<BOPosts> items);
	}
}

/*<Codenesium>
    <Hash>a22a735b00b1b0a8d980cce363cf0bcd</Hash>
</Codenesium>*/