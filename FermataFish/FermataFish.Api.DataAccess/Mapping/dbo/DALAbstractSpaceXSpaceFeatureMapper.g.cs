using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALSpaceXSpaceFeatureMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOSpaceXSpaceFeature dto,
			SpaceXSpaceFeature efSpaceXSpaceFeature)
		{
			efSpaceXSpaceFeature.SetProperties(
				id,
				dto.SpaceFeatureId,
				dto.SpaceId);
		}

		public virtual DTOSpaceXSpaceFeature MapEFToDTO(
			SpaceXSpaceFeature ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOSpaceXSpaceFeature();

			dto.SetProperties(
				ef.Id,
				ef.SpaceFeatureId,
				ef.SpaceId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>c7a9a09131920707ec3b44771fd1303d</Hash>
</Codenesium>*/