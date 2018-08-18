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
    <Hash>d4ba378d6471ee8652cc36b807c37925</Hash>
</Codenesium>*/