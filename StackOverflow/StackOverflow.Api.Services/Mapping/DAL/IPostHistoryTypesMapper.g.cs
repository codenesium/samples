using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostHistoryTypesMapper
	{
		PostHistoryTypes MapModelToEntity(
			int id,
			ApiPostHistoryTypesServerRequestModel model);

		ApiPostHistoryTypesServerResponseModel MapEntityToModel(
			PostHistoryTypes item);

		List<ApiPostHistoryTypesServerResponseModel> MapEntityToModel(
			List<PostHistoryTypes> items);
	}
}

/*<Codenesium>
    <Hash>ea3640324975a62f39c98ebb748da47d</Hash>
</Codenesium>*/