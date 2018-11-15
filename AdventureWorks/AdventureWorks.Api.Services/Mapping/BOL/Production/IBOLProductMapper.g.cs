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
			ApiProductServerRequestModel model);

		ApiProductServerResponseModel MapBOToModel(
			BOProduct boProduct);

		List<ApiProductServerResponseModel> MapBOToModel(
			List<BOProduct> items);
	}
}

/*<Codenesium>
    <Hash>f516b30cbcba726fd6a8d13cbd013bf1</Hash>
</Codenesium>*/