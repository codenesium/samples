using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBOLPostLinkMapper
	{
		BOPostLink MapModelToBO(
			int id,
			ApiPostLinkRequestModel model);

		ApiPostLinkResponseModel MapBOToModel(
			BOPostLink boPostLink);

		List<ApiPostLinkResponseModel> MapBOToModel(
			List<BOPostLink> items);
	}
}

/*<Codenesium>
    <Hash>a729336104c0e4876596178bb5f8e11d</Hash>
</Codenesium>*/