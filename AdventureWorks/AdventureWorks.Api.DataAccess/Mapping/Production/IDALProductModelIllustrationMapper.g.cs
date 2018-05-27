using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductModelIllustrationMapper
	{
		void MapDTOToEF(
			int productModelID,
			DTOProductModelIllustration dto,
			ProductModelIllustration efProductModelIllustration);

		DTOProductModelIllustration MapEFToDTO(
			ProductModelIllustration efProductModelIllustration);
	}
}

/*<Codenesium>
    <Hash>19e711c26801354952bff78380214be9</Hash>
</Codenesium>*/