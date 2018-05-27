using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALSpaceFeatureMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOSpaceFeature dto,
			SpaceFeature efSpaceFeature)
		{
			efSpaceFeature.SetProperties(
				id,
				dto.Name,
				dto.StudioId);
		}

		public virtual DTOSpaceFeature MapEFToDTO(
			SpaceFeature ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSpaceFeature();

			dto.SetProperties(
				ef.Id,
				ef.Name,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>cb43dc44367e1faa54fce32e1c084fe1</Hash>
</Codenesium>*/