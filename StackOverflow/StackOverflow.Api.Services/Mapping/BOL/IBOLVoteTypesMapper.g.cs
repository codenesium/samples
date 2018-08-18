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
    <Hash>2743917e331b0630c47f4d6e36f47643</Hash>
</Codenesium>*/