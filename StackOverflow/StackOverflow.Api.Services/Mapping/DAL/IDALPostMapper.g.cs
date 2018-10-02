using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostMapper
	{
		Post MapBOToEF(
			BOPost bo);

		BOPost MapEFToBO(
			Post efPost);

		List<BOPost> MapEFToBO(
			List<Post> records);
	}
}

/*<Codenesium>
    <Hash>9cc22f99406df40dd646eccd21872fc1</Hash>
</Codenesium>*/