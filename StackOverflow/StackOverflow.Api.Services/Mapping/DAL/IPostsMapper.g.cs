using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostsMapper
	{
		Posts MapModelToEntity(
			int id,
			ApiPostsServerRequestModel model);

		ApiPostsServerResponseModel MapEntityToModel(
			Posts item);

		List<ApiPostsServerResponseModel> MapEntityToModel(
			List<Posts> items);
	}
}

/*<Codenesium>
    <Hash>172f288b53d69aa19387ffbc5c48ec4e</Hash>
</Codenesium>*/