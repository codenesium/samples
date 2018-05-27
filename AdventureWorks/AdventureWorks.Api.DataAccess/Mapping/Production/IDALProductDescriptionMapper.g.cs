using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductDescriptionMapper
	{
		void MapDTOToEF(
			int productDescriptionID,
			DTOProductDescription dto,
			ProductDescription efProductDescription);

		DTOProductDescription MapEFToDTO(
			ProductDescription efProductDescription);
	}
}

/*<Codenesium>
    <Hash>0e7576e96d0ea1b79e8d6dd0246abd3e</Hash>
</Codenesium>*/