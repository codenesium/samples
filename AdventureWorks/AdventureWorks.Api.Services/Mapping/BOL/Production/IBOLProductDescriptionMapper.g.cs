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
    <Hash>8e87056eebbb9302dfd42d3b51b543b2</Hash>
</Codenesium>*/