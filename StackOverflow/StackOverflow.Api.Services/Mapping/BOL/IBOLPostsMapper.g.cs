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
    <Hash>b0bbacebac7860c18cd97073cd4cade8</Hash>
</Codenesium>*/