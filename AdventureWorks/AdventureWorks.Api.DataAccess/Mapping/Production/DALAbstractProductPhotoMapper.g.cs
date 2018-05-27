using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductPhotoMapper
	{
		public virtual void MapDTOToEF(
			int productPhotoID,
			DTOProductPhoto dto,
			ProductPhoto efProductPhoto)
		{
			efProductPhoto.SetProperties(
				productPhotoID,
				dto.LargePhoto,
				dto.LargePhotoFileName,
				dto.ModifiedDate,
				dto.ThumbNailPhoto,
				dto.ThumbnailPhotoFileName);
		}

		public virtual DTOProductPhoto MapEFToDTO(
			ProductPhoto ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductPhoto();

			dto.SetProperties(
				ef.ProductPhotoID,
				ef.LargePhoto,
				ef.LargePhotoFileName,
				ef.ModifiedDate,
				ef.ThumbNailPhoto,
				ef.ThumbnailPhotoFileName);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>caf58dbe3613d07ad220618bd8c55ecb</Hash>
</Codenesium>*/