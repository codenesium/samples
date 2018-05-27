using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductVendorMapper
	{
		void MapDTOToEF(
			int productID,
			DTOProductVendor dto,
			ProductVendor efProductVendor);

		DTOProductVendor MapEFToDTO(
			ProductVendor efProductVendor);
	}
}

/*<Codenesium>
    <Hash>fd6aaf98b0cbf0dcb5a25f0765e14723</Hash>
</Codenesium>*/