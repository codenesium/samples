using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALTagsMapper
	{
		Tags MapModelToEntity(
			int id,
			ApiTagsServerRequestModel model);

		ApiTagsServerResponseModel MapEntityToModel(
			Tags item);

		List<ApiTagsServerResponseModel> MapEntityToModel(
			List<Tags> items);
	}
}

/*<Codenesium>
    <Hash>2ce766bc89ab35fc7d7a792edc9bee14</Hash>
</Codenesium>*/