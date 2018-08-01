using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALCommentsMapper
	{
		Comments MapBOToEF(
			BOComments bo);

		BOComments MapEFToBO(
			Comments efComments);

		List<BOComments> MapEFToBO(
			List<Comments> records);
	}
}

/*<Codenesium>
    <Hash>a4b368c77e213cabb46ba7a215b9a4c1</Hash>
</Codenesium>*/