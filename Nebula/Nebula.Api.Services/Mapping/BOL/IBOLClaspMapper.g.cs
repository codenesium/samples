using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLClaspMapper
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
    <Hash>e7dfa0fbedafe1afd21fcb93dd28a031</Hash>
</Codenesium>*/