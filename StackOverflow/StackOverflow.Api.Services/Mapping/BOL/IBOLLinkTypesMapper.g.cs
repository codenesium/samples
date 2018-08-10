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
    <Hash>fb7174a2a6d76dd36bf54e85f62e750c</Hash>
</Codenesium>*/