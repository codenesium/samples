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
			List<BOProductInventory> items);
	}
}

/*<Codenesium>
    <Hash>d37c57ecae9068bf52761059b8e9a972</Hash>
</Codenesium>*/