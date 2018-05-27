using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALAdminMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOAdmin dto,
			Admin efAdmin)
		{
			efAdmin.SetProperties(
				id,
				dto.Birthday,
				dto.Email,
				dto.FirstName,
				dto.LastName,
				dto.Phone,
				dto.StudioId);
		}

		public virtual DTOAdmin MapEFToDTO(
			Admin ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOAdmin();

			dto.SetProperties(
				ef.Id,
				ef.Birthday,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Phone,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>af524ca57598f747121f9244b166c852</Hash>
</Codenesium>*/