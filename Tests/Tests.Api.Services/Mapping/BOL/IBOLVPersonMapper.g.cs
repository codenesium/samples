using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLVPersonMapper
	{
		BOVPerson MapModelToBO(
			int personId,
			ApiVPersonServerRequestModel model);

		ApiVPersonServerResponseModel MapBOToModel(
			BOVPerson boVPerson);

		List<ApiVPersonServerResponseModel> MapBOToModel(
			List<BOVPerson> items);
	}
}

/*<Codenesium>
    <Hash>0a6b5f833c7abaab61d87752d1b967e8</Hash>
</Codenesium>*/