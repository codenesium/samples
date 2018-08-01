using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLPersonRefMapper
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
    <Hash>2f974269994e7378a0c400f2d7b9fd2b</Hash>
</Codenesium>*/