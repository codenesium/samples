using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALScrapReasonMapper
	{
		public virtual void MapDTOToEF(
			short scrapReasonID,
			DTOScrapReason dto,
			ScrapReason efScrapReason)
		{
			efScrapReason.SetProperties(
				scrapReasonID,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOScrapReason MapEFToDTO(
			ScrapReason ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOScrapReason();

			dto.SetProperties(
				ef.ScrapReasonID,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>64e0e8a1b627d920db3cc7518b107e9c</Hash>
</Codenesium>*/