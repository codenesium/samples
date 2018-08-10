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
    <Hash>7d4d3f7c1563b5eeeea9f2ff81773131</Hash>
</Codenesium>*/