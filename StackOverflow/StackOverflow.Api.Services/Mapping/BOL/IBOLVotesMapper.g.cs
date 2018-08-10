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
    <Hash>4ee1e54a94e578002e8f970fe2abcac1</Hash>
</Codenesium>*/