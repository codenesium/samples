using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductCostHistoryMapper
	{
		DTOProductCostHistory MapModelToDTO(
			int productID,
			ApiProductCostHistoryRequestModel model);

		ApiProductCostHistoryResponseModel MapDTOToModel(
			DTOProductCostHistory dtoProductCostHistory);

		List<ApiProductCostHistoryResponseModel> MapDTOToModel(
			List<DTOProductCostHistory> dtos);
	}
}

/*<Codenesium>
    <Hash>f064af3186972f12f9027c4e80b3b264</Hash>
</Codenesium>*/