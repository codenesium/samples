using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostHistoryTypeMapper
	{
		PostHistoryType MapModelToEntity(
			int id,
			ApiPostHistoryTypeServerRequestModel model);

		ApiPostHistoryTypeServerResponseModel MapEntityToModel(
			PostHistoryType item);

		List<ApiPostHistoryTypeServerResponseModel> MapEntityToModel(
			List<PostHistoryType> items);
	}
}

/*<Codenesium>
    <Hash>1167541de4e1ce69ebc74bae6125b7f4</Hash>
</Codenesium>*/