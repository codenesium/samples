using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductListPriceHistoryMapper
	{
		void MapDTOToEF(
			int productID,
			DTOProductListPriceHistory dto,
			ProductListPriceHistory efProductListPriceHistory);

		DTOProductListPriceHistory MapEFToDTO(
			ProductListPriceHistory efProductListPriceHistory);
	}
}

/*<Codenesium>
    <Hash>a0b8e1a185936535957d82e185a23ba1</Hash>
</Codenesium>*/