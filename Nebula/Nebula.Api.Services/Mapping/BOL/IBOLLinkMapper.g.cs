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
			ApiLinkServerRequestModel model);

		ApiLinkServerResponseModel MapBOToModel(
			BOLink boLink);

		List<ApiLinkServerResponseModel> MapBOToModel(
			List<BOLink> items);
	}
}

/*<Codenesium>
    <Hash>c1fd86e2bf30aa25f58fb446006ecea2</Hash>
</Codenesium>*/