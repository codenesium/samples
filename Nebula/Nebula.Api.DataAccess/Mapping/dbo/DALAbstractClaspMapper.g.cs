using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALClaspMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOClasp dto,
			Clasp efClasp)
		{
			efClasp.SetProperties(
				id,
				dto.NextChainId,
				dto.PreviousChainId);
		}

		public virtual DTOClasp MapEFToDTO(
			Clasp ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOClasp();

			dto.SetProperties(
				ef.Id,
				ef.NextChainId,
				ef.PreviousChainId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>7b9c7bd1566a6afdc37a41bc67da688a</Hash>
</Codenesium>*/