using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLRowVersionCheckMapper
	{
		BORowVersionCheck MapModelToBO(
			int id,
			ApiRowVersionCheckRequestModel model);

		ApiRowVersionCheckResponseModel MapBOToModel(
			BORowVersionCheck boRowVersionCheck);

		List<ApiRowVersionCheckResponseModel> MapBOToModel(
			List<BORowVersionCheck> items);
	}
}

/*<Codenesium>
    <Hash>e7e85d2e881a7e088e058b4eb087d6b6</Hash>
</Codenesium>*/