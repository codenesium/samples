using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALSpaceFeatureMapper
	{
		void MapDTOToEF(
			int id,
			DTOSpaceFeature dto,
			SpaceFeature efSpaceFeature);

		DTOSpaceFeature MapEFToDTO(
			SpaceFeature efSpaceFeature);
	}
}

/*<Codenesium>
    <Hash>6cbe5b466ff94effa380d2aac7e515f7</Hash>
</Codenesium>*/