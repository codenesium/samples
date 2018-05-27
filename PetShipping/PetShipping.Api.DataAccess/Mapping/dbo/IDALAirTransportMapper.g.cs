using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALAirTransportMapper
	{
		void MapDTOToEF(
			int airlineId,
			DTOAirTransport dto,
			AirTransport efAirTransport);

		DTOAirTransport MapEFToDTO(
			AirTransport efAirTransport);
	}
}

/*<Codenesium>
    <Hash>5d8eac8027ff05f277b4a7e332c82a61</Hash>
</Codenesium>*/