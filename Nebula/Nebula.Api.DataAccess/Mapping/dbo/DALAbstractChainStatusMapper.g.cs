using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALChainStatusMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOChainStatus dto,
			ChainStatus efChainStatus)
		{
			efChainStatus.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOChainStatus MapEFToDTO(
			ChainStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOChainStatus();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>8b8551b2e10588a6ca270ed5e294d34c</Hash>
</Codenesium>*/