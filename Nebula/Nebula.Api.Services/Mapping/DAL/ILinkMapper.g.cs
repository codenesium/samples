using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALLinkMapper
	{
		Link MapModelToEntity(
			int id,
			ApiLinkServerRequestModel model);

		ApiLinkServerResponseModel MapEntityToModel(
			Link item);

		List<ApiLinkServerResponseModel> MapEntityToModel(
			List<Link> items);
	}
}

/*<Codenesium>
    <Hash>fac9bf754571d7f8416028523f5bb0b2</Hash>
</Codenesium>*/