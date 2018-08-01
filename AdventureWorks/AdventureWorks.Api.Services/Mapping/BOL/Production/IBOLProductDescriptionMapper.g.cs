using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>1cc3198e77f0077c16b8ea29287deaeb</Hash>
</Codenesium>*/