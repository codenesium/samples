using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductDescriptionMapper
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
    <Hash>20a8ba41843b5ffd8a6a1740740bb7bc</Hash>
</Codenesium>*/