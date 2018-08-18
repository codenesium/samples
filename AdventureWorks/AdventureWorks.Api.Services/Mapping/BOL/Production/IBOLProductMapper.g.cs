using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductMapper
	{
		BOProduct MapModelToBO(
			int productID,
			ApiProductRequestModel model);

		ApiProductResponseModel MapBOToModel(
			BOProduct boProduct);

		List<ApiProductResponseModel> MapBOToModel(
			List<BOProduct> items);
	}
}

/*<Codenesium>
    <Hash>1b8705ac073ee7613718a8fdbb4e8c80</Hash>
</Codenesium>*/