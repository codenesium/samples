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
			ApiIllustrationRequestModel model);

		ApiIllustrationResponseModel MapBOToModel(
			BOIllustration boIllustration);

		List<ApiIllustrationResponseModel> MapBOToModel(
			List<BOIllustration> items);
	}
}

/*<Codenesium>
    <Hash>5e40ae4a5993a1a95f8cf241f7e95d4e</Hash>
</Codenesium>*/