using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductModelIllustrationMapper
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
    <Hash>4d9a49806b2555b4f42c8eaab8df67b3</Hash>
</Codenesium>*/