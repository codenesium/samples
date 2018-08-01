using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLAdminMapper
	{
		BOAdmin MapModelToBO(
			int id,
			ApiAdminRequestModel model);

		ApiAdminResponseModel MapBOToModel(
			BOAdmin boAdmin);

		List<ApiAdminResponseModel> MapBOToModel(
			List<BOAdmin> items);
	}
}

/*<Codenesium>
    <Hash>2384e5b64e2dee33323e8dcf6427bef0</Hash>
</Codenesium>*/