using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public interface IBOLLinkTypesMapper
	{
		BOLinkTypes MapModelToBO(
			int id,
			ApiLinkTypesRequestModel model);

		ApiLinkTypesResponseModel MapBOToModel(
			BOLinkTypes boLinkTypes);

		List<ApiLinkTypesResponseModel> MapBOToModel(
			List<BOLinkTypes> items);
	}
}

/*<Codenesium>
    <Hash>fd357e26c2dfa7cbfbdbab7a1e8c07d6</Hash>
</Codenesium>*/