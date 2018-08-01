using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLVoteTypesMapper
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
    <Hash>2810657435d1c4096da91013780b06f1</Hash>
</Codenesium>*/