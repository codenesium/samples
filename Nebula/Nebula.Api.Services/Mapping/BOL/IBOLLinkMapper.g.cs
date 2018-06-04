using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
			List<BOLink> bos);
	}
}

/*<Codenesium>
    <Hash>1bd739517507092ebbc23643b4144edd</Hash>
</Codenesium>*/