using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductMapper
	{
		Product MapModelToEntity(
			int productID,
			ApiProductServerRequestModel model);

		ApiProductServerResponseModel MapEntityToModel(
			Product item);

		List<ApiProductServerResponseModel> MapEntityToModel(
			List<Product> items);
	}
}

/*<Codenesium>
    <Hash>d89d5b9f2432662cd5f523aed464a819</Hash>
</Codenesium>*/