using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
			List<BOProductInventory> bos);
	}
}

/*<Codenesium>
    <Hash>6eb65f80de24357f9e031c4b32aef0ed</Hash>
</Codenesium>*/