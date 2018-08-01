using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductInventoryMapper
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
    <Hash>9383d0ddc7f7ab21d9fedb6cf7bbcc81</Hash>
</Codenesium>*/