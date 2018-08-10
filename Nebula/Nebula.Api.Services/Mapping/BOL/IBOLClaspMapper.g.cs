using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLClaspMapper
	{
		BOClasp MapModelToBO(
			int id,
			ApiClaspRequestModel model);

		ApiClaspResponseModel MapBOToModel(
			BOClasp boClasp);

		List<ApiClaspResponseModel> MapBOToModel(
			List<BOClasp> items);
	}
}

/*<Codenesium>
    <Hash>d78ae0ff5853faf92d441689464ae866</Hash>
</Codenesium>*/