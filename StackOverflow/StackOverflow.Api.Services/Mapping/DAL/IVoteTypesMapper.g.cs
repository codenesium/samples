using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVoteTypesMapper
	{
		VoteTypes MapModelToEntity(
			int id,
			ApiVoteTypesServerRequestModel model);

		ApiVoteTypesServerResponseModel MapEntityToModel(
			VoteTypes item);

		List<ApiVoteTypesServerResponseModel> MapEntityToModel(
			List<VoteTypes> items);
	}
}

/*<Codenesium>
    <Hash>d724aed8c62db6b035bca366303d2c10</Hash>
</Codenesium>*/