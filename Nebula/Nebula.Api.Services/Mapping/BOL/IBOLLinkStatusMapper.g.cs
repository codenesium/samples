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
			List<BOLinkStatus> bos);
	}
}

/*<Codenesium>
    <Hash>17ba39f6ab3955c3ac5783ec450e5ebe</Hash>
</Codenesium>*/