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
			List<BOProductModelIllustration> items);
	}
}

/*<Codenesium>
    <Hash>354086a9fd0b23bfe847cd4ed5769b99</Hash>
</Codenesium>*/