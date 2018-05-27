using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALClientMapper
	{
		void MapDTOToEF(
			int id,
			DTOClient dto,
			Client efClient);

		DTOClient MapEFToDTO(
			Client efClient);
	}
}

/*<Codenesium>
    <Hash>6a2c215b1d2f79f14fa9a30b74e1d479</Hash>
</Codenesium>*/