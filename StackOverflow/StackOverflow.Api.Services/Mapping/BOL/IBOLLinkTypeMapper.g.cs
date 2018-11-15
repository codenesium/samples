using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLLinkTypeMapper
	{
		BOLinkType MapModelToBO(
			int id,
			ApiLinkTypeServerRequestModel model);

		ApiLinkTypeServerResponseModel MapBOToModel(
			BOLinkType boLinkType);

		List<ApiLinkTypeServerResponseModel> MapBOToModel(
			List<BOLinkType> items);
	}
}

/*<Codenesium>
    <Hash>f8f42cbe31dab918520c290797b88976</Hash>
</Codenesium>*/