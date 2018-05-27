using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALLinkStatusMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOLinkStatus dto,
			LinkStatus efLinkStatus)
		{
			efLinkStatus.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOLinkStatus MapEFToDTO(
			LinkStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLinkStatus();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>ebc89b51c7b58534af57b3d556fbef92</Hash>
</Codenesium>*/