using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLLinkMapper
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
    <Hash>026e0ee876af8ed5d59932dbeaef1f4b</Hash>
</Codenesium>*/