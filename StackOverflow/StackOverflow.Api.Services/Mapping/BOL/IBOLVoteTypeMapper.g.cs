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
			ApiVoteTypeRequestModel model);

		ApiVoteTypeResponseModel MapBOToModel(
			BOVoteType boVoteType);

		List<ApiVoteTypeResponseModel> MapBOToModel(
			List<BOVoteType> items);
	}
}

/*<Codenesium>
    <Hash>e6fbf87685971e02054c78bffafdf0b8</Hash>
</Codenesium>*/