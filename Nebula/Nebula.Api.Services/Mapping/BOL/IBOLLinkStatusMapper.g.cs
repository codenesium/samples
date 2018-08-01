using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLLinkStatusMapper
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
    <Hash>76addfc253ce8b350d3e00d992790495</Hash>
</Codenesium>*/