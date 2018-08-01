using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLVotesMapper
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
    <Hash>c46311ae22cc983452274cdab2cee798</Hash>
</Codenesium>*/