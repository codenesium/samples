using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLTimestampCheckMapper
	{
		BOTimestampCheck MapModelToBO(
			int id,
			ApiTimestampCheckRequestModel model);

		ApiTimestampCheckResponseModel MapBOToModel(
			BOTimestampCheck boTimestampCheck);

		List<ApiTimestampCheckResponseModel> MapBOToModel(
			List<BOTimestampCheck> items);
	}
}

/*<Codenesium>
    <Hash>aee1be82845f24875f1eceabf4a5486e</Hash>
</Codenesium>*/