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
    <Hash>01b0c3b9bf440f6e5451ccddd10825a4</Hash>
</Codenesium>*/