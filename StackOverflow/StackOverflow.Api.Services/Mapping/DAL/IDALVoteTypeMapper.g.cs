using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVoteTypeMapper
	{
		VoteType MapBOToEF(
			BOVoteType bo);

		BOVoteType MapEFToBO(
			VoteType efVoteType);

		List<BOVoteType> MapEFToBO(
			List<VoteType> records);
	}
}

/*<Codenesium>
    <Hash>e8c74316205247b7faea87dfcc02c4fb</Hash>
</Codenesium>*/