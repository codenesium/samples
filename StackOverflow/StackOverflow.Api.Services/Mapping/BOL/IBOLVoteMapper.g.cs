using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLVoteMapper
	{
		BOVote MapModelToBO(
			int id,
			ApiVoteServerRequestModel model);

		ApiVoteServerResponseModel MapBOToModel(
			BOVote boVote);

		List<ApiVoteServerResponseModel> MapBOToModel(
			List<BOVote> items);
	}
}

/*<Codenesium>
    <Hash>2d8c00e2150eb2a1360cb2c40b77244b</Hash>
</Codenesium>*/