using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLLinkLogMapper
	{
		BOLinkLog MapModelToBO(
			int id,
			ApiLinkLogRequestModel model);

		ApiLinkLogResponseModel MapBOToModel(
			BOLinkLog boLinkLog);

		List<ApiLinkLogResponseModel> MapBOToModel(
			List<BOLinkLog> items);
	}
}

/*<Codenesium>
    <Hash>aa6e6f4f9cb55d2140a4532244cae3b8</Hash>
</Codenesium>*/