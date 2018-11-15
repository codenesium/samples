using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLLinkStatusMapper
	{
		BOLinkStatus MapModelToBO(
			int id,
			ApiLinkStatusServerRequestModel model);

		ApiLinkStatusServerResponseModel MapBOToModel(
			BOLinkStatus boLinkStatus);

		List<ApiLinkStatusServerResponseModel> MapBOToModel(
			List<BOLinkStatus> items);
	}
}

/*<Codenesium>
    <Hash>5fefb3e521f2d6a9cba1e0237f34d7dd</Hash>
</Codenesium>*/