using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductModelIllustrationMapper
	{
		BOProductModelIllustration MapModelToBO(
			int productModelID,
			ApiProductModelIllustrationRequestModel model);

		ApiProductModelIllustrationResponseModel MapBOToModel(
			BOProductModelIllustration boProductModelIllustration);

		List<ApiProductModelIllustrationResponseModel> MapBOToModel(
			List<BOProductModelIllustration> items);
	}
}

/*<Codenesium>
    <Hash>6b4a639b633b63d62e698c56de181fab</Hash>
</Codenesium>*/