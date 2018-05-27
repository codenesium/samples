using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALChainMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOChain dto,
			Chain efChain)
		{
			efChain.SetProperties(
				id,
				dto.ChainStatusId,
				dto.ExternalId,
				dto.Name,
				dto.TeamId);
		}

		public virtual DTOChain MapEFToDTO(
			Chain ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOChain();

			dto.SetProperties(
				ef.Id,
				ef.ChainStatusId,
				ef.ExternalId,
				ef.Name,
				ef.TeamId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>3fe9dd80bd50dc8d30cc06a1b4672632</Hash>
</Codenesium>*/