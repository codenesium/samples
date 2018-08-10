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
    <Hash>23fbc62cd821e680e7ed1255cfb563ac</Hash>
</Codenesium>*/