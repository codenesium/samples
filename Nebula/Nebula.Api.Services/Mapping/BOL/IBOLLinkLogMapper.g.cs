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
    <Hash>55b7a2c293abd73bf638685ecfb9735e</Hash>
</Codenesium>*/