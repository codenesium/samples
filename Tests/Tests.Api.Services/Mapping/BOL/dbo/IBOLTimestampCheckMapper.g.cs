using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLTimestampCheckMapper
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
    <Hash>34326901a73a594c0d1fc20542693795</Hash>
</Codenesium>*/