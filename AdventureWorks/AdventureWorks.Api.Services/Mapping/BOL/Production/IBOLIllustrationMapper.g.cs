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
    <Hash>8fe183fc0d84e50a67ba034c6696b049</Hash>
</Codenesium>*/