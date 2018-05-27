using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractDALClientMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOClient dto,
			Client efClient)
		{
			efClient.SetProperties(
				id,
				dto.Email,
				dto.FirstName,
				dto.LastName,
				dto.Notes,
				dto.Phone);
		}

		public virtual DTOClient MapEFToDTO(
			Client ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOClient();

			dto.SetProperties(
				ef.Id,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Notes,
				ef.Phone);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>30ca79803c33a86605dfe73078af2c29</Hash>
</Codenesium>*/