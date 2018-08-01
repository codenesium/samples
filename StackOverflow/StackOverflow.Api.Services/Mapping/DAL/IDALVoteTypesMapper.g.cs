using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IDALVoteTypesMapper
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
    <Hash>5c57876b84dfea37a94fc3de8863a992</Hash>
</Codenesium>*/