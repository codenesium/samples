using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductModelIllustrationMapper
	{
		public virtual void MapDTOToEF(
			int productModelID,
			DTOProductModelIllustration dto,
			ProductModelIllustration efProductModelIllustration)
		{
			efProductModelIllustration.SetProperties(
				productModelID,
				dto.IllustrationID,
				dto.ModifiedDate);
		}

		public virtual DTOProductModelIllustration MapEFToDTO(
			ProductModelIllustration ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductModelIllustration();

			dto.SetProperties(
				ef.ProductModelID,
				ef.IllustrationID,
				ef.ModifiedDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>54477571fc3a31ccec7ae984da824841</Hash>
</Codenesium>*/