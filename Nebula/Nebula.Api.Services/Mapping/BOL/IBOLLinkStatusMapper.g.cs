using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>4c9040433832c3cb4519a36500df2450</Hash>
</Codenesium>*/