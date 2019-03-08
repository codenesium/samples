using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostTypesMapper
	{
		PostTypes MapModelToEntity(
			int id,
			ApiPostTypesServerRequestModel model);

		ApiPostTypesServerResponseModel MapEntityToModel(
			PostTypes item);

		List<ApiPostTypesServerResponseModel> MapEntityToModel(
			List<PostTypes> items);
	}
}

/*<Codenesium>
    <Hash>ea82ff24269eb756b9d146527d51030a</Hash>
</Codenesium>*/