using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLVoteTypesMapper
	{
		BOVoteTypes MapModelToBO(
			int id,
			ApiVoteTypesRequestModel model);

		ApiVoteTypesResponseModel MapBOToModel(
			BOVoteTypes boVoteTypes);

		List<ApiVoteTypesResponseModel> MapBOToModel(
			List<BOVoteTypes> items);
	}
}

/*<Codenesium>
    <Hash>4daf1e7439e381edbb5c4a73c7229ec7</Hash>
</Codenesium>*/