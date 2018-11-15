using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLPersonRefMapper
	{
		BOPersonRef MapModelToBO(
			int id,
			ApiPersonRefServerRequestModel model);

		ApiPersonRefServerResponseModel MapBOToModel(
			BOPersonRef boPersonRef);

		List<ApiPersonRefServerResponseModel> MapBOToModel(
			List<BOPersonRef> items);
	}
}

/*<Codenesium>
    <Hash>cfd82f7fd1352acc6d51c8efb1b31750</Hash>
</Codenesium>*/