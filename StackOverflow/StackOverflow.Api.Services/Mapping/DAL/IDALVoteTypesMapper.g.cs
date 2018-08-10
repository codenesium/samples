using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVoteTypesMapper
	{
		VoteTypes MapBOToEF(
			BOVoteTypes bo);

		BOVoteTypes MapEFToBO(
			VoteTypes efVoteTypes);

		List<BOVoteTypes> MapEFToBO(
			List<VoteTypes> records);
	}
}

/*<Codenesium>
    <Hash>6b825c14edc8feff48e1750cc94d3313</Hash>
</Codenesium>*/