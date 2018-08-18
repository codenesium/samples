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
    <Hash>b8f1d4dbd2dbcfa27b1d0f453caaf60b</Hash>
</Codenesium>*/