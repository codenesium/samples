using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLLinkMapper
	{
		BOLink MapModelToBO(
			int id,
			ApiLinkRequestModel model);

		ApiLinkResponseModel MapBOToModel(
			BOLink boLink);

		List<ApiLinkResponseModel> MapBOToModel(
			List<BOLink> items);
	}
}

/*<Codenesium>
    <Hash>2cdb459b638246669d1cda1ed9b98ba1</Hash>
</Codenesium>*/