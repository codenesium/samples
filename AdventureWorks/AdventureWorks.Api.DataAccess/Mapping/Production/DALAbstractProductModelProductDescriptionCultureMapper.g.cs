using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductModelProductDescriptionCultureMapper
	{
		public virtual void MapDTOToEF(
			int productModelID,
			DTOProductModelProductDescriptionCulture dto,
			ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture)
		{
			efProductModelProductDescriptionCulture.SetProperties(
				productModelID,
				dto.CultureID,
				dto.ModifiedDate,
				dto.ProductDescriptionID);
		}

		public virtual DTOProductModelProductDescriptionCulture MapEFToDTO(
			ProductModelProductDescriptionCulture ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductModelProductDescriptionCulture();

			dto.SetProperties(
				ef.ProductModelID,
				ef.CultureID,
				ef.ModifiedDate,
				ef.ProductDescriptionID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>ef00f6acf2a8cc9a3b5662f4f2880002</Hash>
</Codenesium>*/