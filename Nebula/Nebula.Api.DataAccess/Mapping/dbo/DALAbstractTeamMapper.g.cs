using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALTeamMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOTeam dto,
			Team efTeam)
		{
			efTeam.SetProperties(
				id,
				dto.Name,
				dto.OrganizationId);
		}

		public virtual DTOTeam MapEFToDTO(
			Team ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOTeam();

			dto.SetProperties(
				ef.Id,
				ef.Name,
				ef.OrganizationId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>e07fd3cc273e19e22235ca2965dbb3a7</Hash>
</Codenesium>*/