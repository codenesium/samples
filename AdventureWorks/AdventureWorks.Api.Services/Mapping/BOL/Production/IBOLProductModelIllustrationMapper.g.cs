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
    <Hash>37734baa95885d2fe7f5d8bb0a7fa138</Hash>
</Codenesium>*/