using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLLinkTypesMapper
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
    <Hash>bc1a876ed575965f3b3457f051521fe9</Hash>
</Codenesium>*/