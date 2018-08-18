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
    <Hash>bc86487161658cdf0fdaae725960d30d</Hash>
</Codenesium>*/