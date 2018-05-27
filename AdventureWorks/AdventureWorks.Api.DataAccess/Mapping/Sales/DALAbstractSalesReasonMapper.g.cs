using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALSalesReasonMapper
	{
		public virtual void MapDTOToEF(
			int salesReasonID,
			DTOSalesReason dto,
			SalesReason efSalesReason)
		{
			efSalesReason.SetProperties(
				salesReasonID,
				dto.ModifiedDate,
				dto.Name,
				dto.ReasonType);
		}

		public virtual DTOSalesReason MapEFToDTO(
			SalesReason ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSalesReason();

			dto.SetProperties(
				ef.SalesReasonID,
				ef.ModifiedDate,
				ef.Name,
				ef.ReasonType);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>4a8f9bae7251c2f93393ddf0ed0c507e</Hash>
</Codenesium>*/