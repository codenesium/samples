using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLSysdiagramMapper
	{
		BOSysdiagram MapModelToBO(
			int diagramId,
			ApiSysdiagramRequestModel model);

		ApiSysdiagramResponseModel MapBOToModel(
			BOSysdiagram boSysdiagram);

		List<ApiSysdiagramResponseModel> MapBOToModel(
			List<BOSysdiagram> items);
	}
}

/*<Codenesium>
    <Hash>5409f6d739a1f70995f6987e727e79ca</Hash>
</Codenesium>*/