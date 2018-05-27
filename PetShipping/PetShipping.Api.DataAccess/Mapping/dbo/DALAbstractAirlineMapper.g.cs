using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALAirlineMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOAirline dto,
			Airline efAirline)
		{
			efAirline.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOAirline MapEFToDTO(
			Airline ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOAirline();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>92253772897074e4a710d69e1ed932c4</Hash>
</Codenesium>*/