using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALLocationMapper
	{
		public virtual void MapDTOToEF(
			short locationID,
			DTOLocation dto,
			Location efLocation)
		{
			efLocation.SetProperties(
				locationID,
				dto.Availability,
				dto.CostRate,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOLocation MapEFToDTO(
			Location ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLocation();

			dto.SetProperties(
				ef.LocationID,
				ef.Availability,
				ef.CostRate,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b1ad05cecaafe1ec1ab7b1c791a92e0c</Hash>
</Codenesium>*/