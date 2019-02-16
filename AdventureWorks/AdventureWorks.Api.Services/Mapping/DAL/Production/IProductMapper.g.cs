using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductMapper
	{
		Product MapModelToBO(
			int productID,
			ApiProductServerRequestModel model);

		ApiProductServerResponseModel MapBOToModel(
			Product item);

		List<ApiProductServerResponseModel> MapBOToModel(
			List<Product> items);
	}
}

/*<Codenesium>
    <Hash>c9b855db596f5a34f598a520c1870b4c</Hash>
</Codenesium>*/