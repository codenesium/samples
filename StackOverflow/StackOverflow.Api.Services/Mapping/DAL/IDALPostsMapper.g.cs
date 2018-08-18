using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostsMapper
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
    <Hash>7f1a2e259b526f93b243662f90c9a60b</Hash>
</Codenesium>*/