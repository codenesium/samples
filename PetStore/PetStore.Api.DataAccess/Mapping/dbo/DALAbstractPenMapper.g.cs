using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractDALPenMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOPen dto,
			Pen efPen)
		{
			efPen.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOPen MapEFToDTO(
			Pen ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPen();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b8afa68bfc7f85fcbcbd96815c8067bf</Hash>
</Codenesium>*/