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
			ApiPersonRefRequestModel model);

		ApiPersonRefResponseModel MapBOToModel(
			BOPersonRef boPersonRef);

		List<ApiPersonRefResponseModel> MapBOToModel(
			List<BOPersonRef> items);
	}
}

/*<Codenesium>
    <Hash>3f9299f9970bb17057445b8321d5217b</Hash>
</Codenesium>*/