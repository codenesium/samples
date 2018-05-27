using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductPhotoMapper
	{
		void MapDTOToEF(
			int productPhotoID,
			DTOProductPhoto dto,
			ProductPhoto efProductPhoto);

		DTOProductPhoto MapEFToDTO(
			ProductPhoto efProductPhoto);
	}
}

/*<Codenesium>
    <Hash>e3b0ad16df92f58d1b9d36a1d80a0853</Hash>
</Codenesium>*/