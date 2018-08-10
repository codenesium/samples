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
			ApiLinkStatusRequestModel model);

		ApiLinkStatusResponseModel MapBOToModel(
			BOLinkStatus boLinkStatus);

		List<ApiLinkStatusResponseModel> MapBOToModel(
			List<BOLinkStatus> items);
	}
}

/*<Codenesium>
    <Hash>4e80507331151d2ca1672c8879c61e27</Hash>
</Codenesium>*/