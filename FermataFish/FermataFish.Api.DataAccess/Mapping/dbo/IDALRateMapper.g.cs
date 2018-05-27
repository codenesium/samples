using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALRateMapper
	{
		void MapDTOToEF(
			int id,
			DTORate dto,
			Rate efRate);

		DTORate MapEFToDTO(
			Rate efRate);
	}
}

/*<Codenesium>
    <Hash>e85f70948f35272abc4fc5cf71c66931</Hash>
</Codenesium>*/