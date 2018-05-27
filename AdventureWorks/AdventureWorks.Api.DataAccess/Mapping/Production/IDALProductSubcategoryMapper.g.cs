using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductSubcategoryMapper
	{
		void MapDTOToEF(
			int productSubcategoryID,
			DTOProductSubcategory dto,
			ProductSubcategory efProductSubcategory);

		DTOProductSubcategory MapEFToDTO(
			ProductSubcategory efProductSubcategory);
	}
}

/*<Codenesium>
    <Hash>9f9b7fee6318c57bb64e2519dfbfd38e</Hash>
</Codenesium>*/