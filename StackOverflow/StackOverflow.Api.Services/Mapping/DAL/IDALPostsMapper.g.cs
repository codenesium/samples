using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALPostsMapper
	{
		Posts MapBOToEF(
			BOPosts bo);

		BOPosts MapEFToBO(
			Posts efPosts);

		List<BOPosts> MapEFToBO(
			List<Posts> records);
	}
}

/*<Codenesium>
    <Hash>9fc52b8b689a8c4054ad3c5a32947750</Hash>
</Codenesium>*/