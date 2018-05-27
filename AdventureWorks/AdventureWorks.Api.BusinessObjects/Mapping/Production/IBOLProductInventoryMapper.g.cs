using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductInventoryMapper
	{
		DTOProductInventory MapModelToDTO(
			int productID,
			ApiProductInventoryRequestModel model);

		ApiProductInventoryResponseModel MapDTOToModel(
			DTOProductInventory dtoProductInventory);

		List<ApiProductInventoryResponseModel> MapDTOToModel(
			List<DTOProductInventory> dtos);
	}
}

/*<Codenesium>
    <Hash>03d09988ee8698eb086ef17cd452d05b</Hash>
</Codenesium>*/