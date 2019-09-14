using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostHistoryMapper
	{
		PostHistory MapModelToEntity(
			int id,
			ApiPostHistoryServerRequestModel model);

		ApiPostHistoryServerResponseModel MapEntityToModel(
			PostHistory item);

		List<ApiPostHistoryServerResponseModel> MapEntityToModel(
			List<PostHistory> items);
	}
}

/*<Codenesium>
    <Hash>9f8267dbf416c9fc71e79018ee37f44f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/