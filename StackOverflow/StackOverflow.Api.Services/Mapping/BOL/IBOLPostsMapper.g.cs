using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLPostsMapper
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
    <Hash>b1ce2e081459d7e685ded7bea9af4bfb</Hash>
</Codenesium>*/