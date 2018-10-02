using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLVProductAndDescriptionMapper
	{
		BOVProductAndDescription MapModelToBO(
			string cultureID,
			ApiVProductAndDescriptionRequestModel model);

		ApiVProductAndDescriptionResponseModel MapBOToModel(
			BOVProductAndDescription boVProductAndDescription);

		List<ApiVProductAndDescriptionResponseModel> MapBOToModel(
			List<BOVProductAndDescription> items);
	}
}

/*<Codenesium>
    <Hash>5083928c4c44ecdca23f01b6b81484a9</Hash>
</Codenesium>*/