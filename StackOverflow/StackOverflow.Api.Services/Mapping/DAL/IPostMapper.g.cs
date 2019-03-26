using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostMapper
	{
		Post MapModelToEntity(
			int id,
			ApiPostServerRequestModel model);

		ApiPostServerResponseModel MapEntityToModel(
			Post item);

		List<ApiPostServerResponseModel> MapEntityToModel(
			List<Post> items);
	}
}

/*<Codenesium>
    <Hash>6b77fe7ededb76c21e8a21fee8e5792c</Hash>
</Codenesium>*/