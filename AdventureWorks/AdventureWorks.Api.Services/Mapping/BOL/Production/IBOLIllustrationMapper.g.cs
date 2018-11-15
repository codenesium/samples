using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLIllustrationMapper
	{
		BOIllustration MapModelToBO(
			int illustrationID,
			ApiIllustrationServerRequestModel model);

		ApiIllustrationServerResponseModel MapBOToModel(
			BOIllustration boIllustration);

		List<ApiIllustrationServerResponseModel> MapBOToModel(
			List<BOIllustration> items);
	}
}

/*<Codenesium>
    <Hash>60714934823528f4f861d737156e5a09</Hash>
</Codenesium>*/