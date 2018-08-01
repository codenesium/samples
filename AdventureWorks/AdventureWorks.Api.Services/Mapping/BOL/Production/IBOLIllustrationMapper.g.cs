using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLIllustrationMapper
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
    <Hash>1d809ebe52c335ab8c2866b979a49b9b</Hash>
</Codenesium>*/