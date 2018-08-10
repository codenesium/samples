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
			ApiProductDescriptionRequestModel model);

		ApiProductDescriptionResponseModel MapBOToModel(
			BOProductDescription boProductDescription);

		List<ApiProductDescriptionResponseModel> MapBOToModel(
			List<BOProductDescription> items);
	}
}

/*<Codenesium>
    <Hash>a34c49d594ffe5c3a7358a89406fccbb</Hash>
</Codenesium>*/