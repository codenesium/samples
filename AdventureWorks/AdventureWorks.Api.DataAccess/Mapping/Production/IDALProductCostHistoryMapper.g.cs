using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductCostHistoryMapper
	{
		void MapDTOToEF(
			int productID,
			DTOProductCostHistory dto,
			ProductCostHistory efProductCostHistory);

		DTOProductCostHistory MapEFToDTO(
			ProductCostHistory efProductCostHistory);
	}
}

/*<Codenesium>
    <Hash>e35603f22d1ec8b4a016d043936d5864</Hash>
</Codenesium>*/