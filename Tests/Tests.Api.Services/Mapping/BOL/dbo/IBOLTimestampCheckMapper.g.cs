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
			ApiTimestampCheckServerRequestModel model);

		ApiTimestampCheckServerResponseModel MapBOToModel(
			BOTimestampCheck boTimestampCheck);

		List<ApiTimestampCheckServerResponseModel> MapBOToModel(
			List<BOTimestampCheck> items);
	}
}

/*<Codenesium>
    <Hash>622a96a52dc45e1b68947a545bdd451d</Hash>
</Codenesium>*/