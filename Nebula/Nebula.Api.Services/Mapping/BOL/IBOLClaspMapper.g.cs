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
			ApiClaspServerRequestModel model);

		ApiClaspServerResponseModel MapBOToModel(
			BOClasp boClasp);

		List<ApiClaspServerResponseModel> MapBOToModel(
			List<BOClasp> items);
	}
}

/*<Codenesium>
    <Hash>d2e3927523d59cc5dd9a19b23bd26027</Hash>
</Codenesium>*/