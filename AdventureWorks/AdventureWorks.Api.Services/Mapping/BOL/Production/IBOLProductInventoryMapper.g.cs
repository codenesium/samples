using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductInventoryMapper
	{
		BOProductInventory MapModelToBO(
			int productID,
			ApiProductInventoryRequestModel model);

		ApiProductInventoryResponseModel MapBOToModel(
			BOProductInventory boProductInventory);

		List<ApiProductInventoryResponseModel> MapBOToModel(
			List<BOProductInventory> items);
	}
}

/*<Codenesium>
    <Hash>75ef3255a1fe864c4228451e1bda034c</Hash>
</Codenesium>*/