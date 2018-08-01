using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALVotesMapper
	{
		Votes MapBOToEF(
			BOVotes bo);

		BOVotes MapEFToBO(
			Votes efVotes);

		List<BOVotes> MapEFToBO(
			List<Votes> records);
	}
}

/*<Codenesium>
    <Hash>a9fb016215c41c49efa3abe99dd0c6ed</Hash>
</Codenesium>*/