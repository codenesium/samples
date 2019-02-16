using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALVoteMapper
	{
		Vote MapModelToEntity(
			int id,
			ApiVoteServerRequestModel model);

		ApiVoteServerResponseModel MapEntityToModel(
			Vote item);

		List<ApiVoteServerResponseModel> MapEntityToModel(
			List<Vote> items);
	}
}

/*<Codenesium>
    <Hash>ddd1ff8f6e4b28e6fccc0666d5fb75f7</Hash>
</Codenesium>*/