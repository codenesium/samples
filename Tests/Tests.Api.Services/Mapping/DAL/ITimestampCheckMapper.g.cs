using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTimestampCheckMapper
	{
		TimestampCheck MapModelToEntity(
			int id,
			ApiTimestampCheckServerRequestModel model);

		ApiTimestampCheckServerResponseModel MapEntityToModel(
			TimestampCheck item);

		List<ApiTimestampCheckServerResponseModel> MapEntityToModel(
			List<TimestampCheck> items);
	}
}

/*<Codenesium>
    <Hash>161c04c88175b47fa7ac4ec9ec4dd404</Hash>
</Codenesium>*/