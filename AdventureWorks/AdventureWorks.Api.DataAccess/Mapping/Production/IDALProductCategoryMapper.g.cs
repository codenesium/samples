using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductCategoryMapper
	{
		void MapDTOToEF(
			int productCategoryID,
			DTOProductCategory dto,
			ProductCategory efProductCategory);

		DTOProductCategory MapEFToDTO(
			ProductCategory efProductCategory);
	}
}

/*<Codenesium>
    <Hash>144a204c4aa4961e2e672b3b4bdd2e80</Hash>
</Codenesium>*/