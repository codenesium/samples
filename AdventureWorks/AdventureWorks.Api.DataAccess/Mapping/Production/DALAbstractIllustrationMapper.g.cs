using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALIllustrationMapper
	{
		public virtual void MapDTOToEF(
			int illustrationID,
			DTOIllustration dto,
			Illustration efIllustration)
		{
			efIllustration.SetProperties(
				illustrationID,
				dto.Diagram,
				dto.ModifiedDate);
		}

		public virtual DTOIllustration MapEFToDTO(
			Illustration ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOIllustration();

			dto.SetProperties(
				ef.IllustrationID,
				ef.Diagram,
				ef.ModifiedDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>00d23bcb01efb171d32b1b70f2542403</Hash>
</Codenesium>*/