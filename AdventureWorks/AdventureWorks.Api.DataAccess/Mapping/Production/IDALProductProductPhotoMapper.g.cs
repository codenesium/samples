using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductProductPhotoMapper
	{
		void MapDTOToEF(
			int productID,
			DTOProductProductPhoto dto,
			ProductProductPhoto efProductProductPhoto);

		DTOProductProductPhoto MapEFToDTO(
			ProductProductPhoto efProductProductPhoto);
	}
}

/*<Codenesium>
    <Hash>5ec8845c0b4a4297464035f6ab86df22</Hash>
</Codenesium>*/