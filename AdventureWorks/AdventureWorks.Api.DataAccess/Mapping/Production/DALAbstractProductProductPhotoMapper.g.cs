using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductProductPhotoMapper
	{
		public virtual void MapDTOToEF(
			int productID,
			DTOProductProductPhoto dto,
			ProductProductPhoto efProductProductPhoto)
		{
			efProductProductPhoto.SetProperties(
				productID,
				dto.ModifiedDate,
				dto.Primary,
				dto.ProductPhotoID);
		}

		public virtual DTOProductProductPhoto MapEFToDTO(
			ProductProductPhoto ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductProductPhoto();

			dto.SetProperties(
				ef.ProductID,
				ef.ModifiedDate,
				ef.Primary,
				ef.ProductPhotoID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>762269ecd39b3f811d51187f77c3abd0</Hash>
</Codenesium>*/