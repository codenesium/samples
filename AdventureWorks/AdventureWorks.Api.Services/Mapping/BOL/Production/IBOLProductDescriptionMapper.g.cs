using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductDescriptionMapper
	{
		BOProductDescription MapModelToBO(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel model);

		ApiProductDescriptionServerResponseModel MapBOToModel(
			BOProductDescription boProductDescription);

		List<ApiProductDescriptionServerResponseModel> MapBOToModel(
			List<BOProductDescription> items);
	}
}

/*<Codenesium>
    <Hash>b9af7dcd15029558bf1b028f87e45daf</Hash>
</Codenesium>*/