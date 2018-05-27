using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALOrganizationMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOOrganization dto,
			Organization efOrganization)
		{
			efOrganization.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOOrganization MapEFToDTO(
			Organization ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOOrganization();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>28965b188a8638c32733d77ff7db323a</Hash>
</Codenesium>*/