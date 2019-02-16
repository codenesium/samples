using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostTypeMapper
	{
		PostType MapModelToEntity(
			int id,
			ApiPostTypeServerRequestModel model);

		ApiPostTypeServerResponseModel MapEntityToModel(
			PostType item);

		List<ApiPostTypeServerResponseModel> MapEntityToModel(
			List<PostType> items);
	}
}

/*<Codenesium>
    <Hash>9fcf9150cad646c43f70669f9089daa0</Hash>
</Codenesium>*/