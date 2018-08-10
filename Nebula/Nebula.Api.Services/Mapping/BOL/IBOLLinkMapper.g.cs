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
    <Hash>44c4effc4e1a11b96bcfa9d5efefaedb</Hash>
</Codenesium>*/