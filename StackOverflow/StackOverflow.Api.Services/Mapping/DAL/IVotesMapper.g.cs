using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVotesMapper
	{
		Votes MapModelToEntity(
			int id,
			ApiVotesServerRequestModel model);

		ApiVotesServerResponseModel MapEntityToModel(
			Votes item);

		List<ApiVotesServerResponseModel> MapEntityToModel(
			List<Votes> items);
	}
}

/*<Codenesium>
    <Hash>c38a33d75e75884b09df2a3a2de18c24</Hash>
</Codenesium>*/