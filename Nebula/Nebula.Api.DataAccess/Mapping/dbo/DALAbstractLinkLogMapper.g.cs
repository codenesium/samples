using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALLinkLogMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOLinkLog dto,
			LinkLog efLinkLog)
		{
			efLinkLog.SetProperties(
				id,
				dto.DateEntered,
				dto.LinkId,
				dto.Log);
		}

		public virtual DTOLinkLog MapEFToDTO(
			LinkLog ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLinkLog();

			dto.SetProperties(
				ef.Id,
				ef.DateEntered,
				ef.LinkId,
				ef.Log);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>d600271400ce7c6880a665d411b06294</Hash>
</Codenesium>*/