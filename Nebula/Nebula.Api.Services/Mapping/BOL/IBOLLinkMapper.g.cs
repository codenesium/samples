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
			List<BOLink> items);
	}
}

/*<Codenesium>
    <Hash>ca46231a0de89ede4c46f4e7032b221d</Hash>
</Codenesium>*/