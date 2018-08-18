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
    <Hash>9dbfaee5e656c3a2de84f256c205facb</Hash>
</Codenesium>*/