using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALCommentMapper
	{
		Comment MapBOToEF(
			BOComment bo);

		BOComment MapEFToBO(
			Comment efComment);

		List<BOComment> MapEFToBO(
			List<Comment> records);
	}
}

/*<Codenesium>
    <Hash>266510eb8db5659b853aa1bd868872c3</Hash>
</Codenesium>*/