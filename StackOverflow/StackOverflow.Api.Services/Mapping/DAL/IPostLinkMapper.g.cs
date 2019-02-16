using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALPostLinkMapper
	{
		PostLink MapModelToEntity(
			int id,
			ApiPostLinkServerRequestModel model);

		ApiPostLinkServerResponseModel MapEntityToModel(
			PostLink item);

		List<ApiPostLinkServerResponseModel> MapEntityToModel(
			List<PostLink> items);
	}
}

/*<Codenesium>
    <Hash>904b788a0a675443f33f67cee2c79c55</Hash>
</Codenesium>*/