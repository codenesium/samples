using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IDALLinkTypesMapper
	{
		LinkTypes MapModelToEntity(
			int id,
			ApiLinkTypesServerRequestModel model);

		ApiLinkTypesServerResponseModel MapEntityToModel(
			LinkTypes item);

		List<ApiLinkTypesServerResponseModel> MapEntityToModel(
			List<LinkTypes> items);
	}
}

/*<Codenesium>
    <Hash>c554a9717471d82ee00aa87ef7ca99f1</Hash>
</Codenesium>*/