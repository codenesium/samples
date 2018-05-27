using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALHandlerMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOHandler dto,
			Handler efHandler)
		{
			efHandler.SetProperties(
				id,
				dto.CountryId,
				dto.Email,
				dto.FirstName,
				dto.LastName,
				dto.Phone);
		}

		public virtual DTOHandler MapEFToDTO(
			Handler ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOHandler();

			dto.SetProperties(
				ef.Id,
				ef.CountryId,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Phone);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>22372cfb7131f80b2782d79a53916ade</Hash>
</Codenesium>*/