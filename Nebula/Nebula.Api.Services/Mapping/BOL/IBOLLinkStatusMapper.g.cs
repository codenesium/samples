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
    <Hash>a8e5590763c608a360f4df07ae099a2d</Hash>
</Codenesium>*/