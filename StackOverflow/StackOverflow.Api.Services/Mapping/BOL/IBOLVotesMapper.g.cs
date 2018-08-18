using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLVotesMapper
	{
		BOVotes MapModelToBO(
			int id,
			ApiVotesRequestModel model);

		ApiVotesResponseModel MapBOToModel(
			BOVotes boVotes);

		List<ApiVotesResponseModel> MapBOToModel(
			List<BOVotes> items);
	}
}

/*<Codenesium>
    <Hash>a39918adff3a3d57eda3b558820c4dec</Hash>
</Codenesium>*/