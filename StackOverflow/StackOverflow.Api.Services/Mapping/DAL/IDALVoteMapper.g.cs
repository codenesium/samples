using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVoteMapper
	{
		Vote MapBOToEF(
			BOVote bo);

		BOVote MapEFToBO(
			Vote efVote);

		List<BOVote> MapEFToBO(
			List<Vote> records);
	}
}

/*<Codenesium>
    <Hash>721e75f9f47794672bbeeb647501159c</Hash>
</Codenesium>*/