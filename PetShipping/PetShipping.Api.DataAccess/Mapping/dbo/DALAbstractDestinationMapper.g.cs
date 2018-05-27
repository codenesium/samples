using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALDestinationMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTODestination dto,
			Destination efDestination)
		{
			efDestination.SetProperties(
				id,
				dto.CountryId,
				dto.Name,
				dto.Order);
		}

		public virtual DTODestination MapEFToDTO(
			Destination ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTODestination();

			dto.SetProperties(
				ef.Id,
				ef.CountryId,
				ef.Name,
				ef.Order);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>23fdff65bca67369106555b78f3e8f73</Hash>
</Codenesium>*/