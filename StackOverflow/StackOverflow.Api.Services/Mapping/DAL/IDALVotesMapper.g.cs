using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVotesMapper
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
    <Hash>f6816b9aec2d86ea304b68b1e2fa083f</Hash>
</Codenesium>*/