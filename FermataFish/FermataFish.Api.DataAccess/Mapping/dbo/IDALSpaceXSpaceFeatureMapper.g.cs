using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALSpaceXSpaceFeatureMapper
	{
		void MapDTOToEF(
			int id,
			DTOSpaceXSpaceFeature dto,
			SpaceXSpaceFeature efSpaceXSpaceFeature);

		DTOSpaceXSpaceFeature MapEFToDTO(
			SpaceXSpaceFeature efSpaceXSpaceFeature);
	}
}

/*<Codenesium>
    <Hash>a9f03c5e2299bc0d69c78446b3d7fffe</Hash>
</Codenesium>*/