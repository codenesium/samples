using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductModelMapper
	{
		void MapDTOToEF(
			int productModelID,
			DTOProductModel dto,
			ProductModel efProductModel);

		DTOProductModel MapEFToDTO(
			ProductModel efProductModel);
	}
}

/*<Codenesium>
    <Hash>d41a8c37b29e394473f9268aff6d9c63</Hash>
</Codenesium>*/