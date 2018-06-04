using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
			List<BOClasp> bos);
	}
}

/*<Codenesium>
    <Hash>8252544d1576b57c26ba9b5508de7ce4</Hash>
</Codenesium>*/