using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLVoteTypeMapper
	{
		BOVoteType MapModelToBO(
			int id,
			ApiVoteTypeServerRequestModel model);

		ApiVoteTypeServerResponseModel MapBOToModel(
			BOVoteType boVoteType);

		List<ApiVoteTypeServerResponseModel> MapBOToModel(
			List<BOVoteType> items);
	}
}

/*<Codenesium>
    <Hash>ecce13be86f85945735872b3798ce1de</Hash>
</Codenesium>*/