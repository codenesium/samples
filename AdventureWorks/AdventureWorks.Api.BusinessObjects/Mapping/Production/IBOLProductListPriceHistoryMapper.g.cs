using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLProductListPriceHistoryMapper
	{
		DTOProductListPriceHistory MapModelToDTO(
			int productID,
			ApiProductListPriceHistoryRequestModel model);

		ApiProductListPriceHistoryResponseModel MapDTOToModel(
			DTOProductListPriceHistory dtoProductListPriceHistory);

		List<ApiProductListPriceHistoryResponseModel> MapDTOToModel(
			List<DTOProductListPriceHistory> dtos);
	}
}

/*<Codenesium>
    <Hash>3e0563a623df3bccc0e23a1a279ff3e9</Hash>
</Codenesium>*/