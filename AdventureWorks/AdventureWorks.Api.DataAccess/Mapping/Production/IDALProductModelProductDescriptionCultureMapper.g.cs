using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductModelProductDescriptionCultureMapper
	{
		void MapDTOToEF(
			int productModelID,
			DTOProductModelProductDescriptionCulture dto,
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

		DTOProductModelProductDescriptionCulture MapEFToDTO(
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);
	}
}

/*<Codenesium>
    <Hash>a8b8ba73915e92d7d9270cdcf63cbedc</Hash>
</Codenesium>*/