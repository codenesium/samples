using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostLinksMapper
	{
		PostLinks MapModelToEntity(
			int id,
			ApiPostLinksServerRequestModel model);

		ApiPostLinksServerResponseModel MapEntityToModel(
			PostLinks item);

		List<ApiPostLinksServerResponseModel> MapEntityToModel(
			List<PostLinks> items);
	}
}

/*<Codenesium>
    <Hash>377d411bed6d921d7c3bd39e67c10b08</Hash>
</Codenesium>*/