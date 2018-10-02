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
			ApiVoteRequestModel model);

		ApiVoteResponseModel MapBOToModel(
			BOVote boVote);

		List<ApiVoteResponseModel> MapBOToModel(
			List<BOVote> items);
	}
}

/*<Codenesium>
    <Hash>2a71d09d42842e86af954a7b03726d50</Hash>
</Codenesium>*/