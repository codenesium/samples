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
			ApiPostLinkServerRequestModel model);

		ApiPostLinkServerResponseModel MapBOToModel(
			BOPostLink boPostLink);

		List<ApiPostLinkServerResponseModel> MapBOToModel(
			List<BOPostLink> items);
	}
}

/*<Codenesium>
    <Hash>89751f4c0104c6f775462cadeedb4f70</Hash>
</Codenesium>*/