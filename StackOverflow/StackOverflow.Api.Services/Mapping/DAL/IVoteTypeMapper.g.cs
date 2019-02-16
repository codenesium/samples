using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVoteTypeMapper
	{
		VoteType MapModelToEntity(
			int id,
			ApiVoteTypeServerRequestModel model);

		ApiVoteTypeServerResponseModel MapEntityToModel(
			VoteType item);

		List<ApiVoteTypeServerResponseModel> MapEntityToModel(
			List<VoteType> items);
	}
}

/*<Codenesium>
    <Hash>3439a0b4b1aa14b85496db01371f6bc3</Hash>
</Codenesium>*/