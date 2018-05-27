using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductDescriptionMapper
	{
		public virtual void MapDTOToEF(
			int productDescriptionID,
			DTOProductDescription dto,
			ProductDescription efProductDescription)
		{
			efProductDescription.SetProperties(
				productDescriptionID,
				dto.Description,
				dto.ModifiedDate,
				dto.Rowguid);
		}

		public virtual DTOProductDescription MapEFToDTO(
			ProductDescription ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductDescription();

			dto.SetProperties(
				ef.ProductDescriptionID,
				ef.Description,
				ef.ModifiedDate,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>5db48b936f3b261bae400b60cfd55147</Hash>
</Codenesium>*/