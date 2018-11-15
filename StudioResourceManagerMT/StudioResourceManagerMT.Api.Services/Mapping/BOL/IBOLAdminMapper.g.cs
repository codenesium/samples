using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLAdminMapper
	{
		BOAdmin MapModelToBO(
			int id,
			ApiAdminServerRequestModel model);

		ApiAdminServerResponseModel MapBOToModel(
			BOAdmin boAdmin);

		List<ApiAdminServerResponseModel> MapBOToModel(
			List<BOAdmin> items);
	}
}

/*<Codenesium>
    <Hash>b318aa052baa19d405510c71f6d305c2</Hash>
</Codenesium>*/