using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
			List<BOProductModelIllustration> bos);
	}
}

/*<Codenesium>
    <Hash>d28f6af10bbaa8a66ccb6fec5f119b2a</Hash>
</Codenesium>*/