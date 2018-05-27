using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALAirlineMapper
	{
		void MapDTOToEF(
			int id,
			DTOAirline dto,
			Airline efAirline);

		DTOAirline MapEFToDTO(
			Airline efAirline);
	}
}

/*<Codenesium>
    <Hash>9daf1ad8cc8a4ba30fdcd0b31667c335</Hash>
</Codenesium>*/