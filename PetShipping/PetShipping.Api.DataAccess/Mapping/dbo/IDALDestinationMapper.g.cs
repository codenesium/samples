using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALDestinationMapper
	{
		void MapDTOToEF(
			int id,
			DTODestination dto,
			Destination efDestination);

		DTODestination MapEFToDTO(
			Destination efDestination);
	}
}

/*<Codenesium>
    <Hash>aac7d43a225d5244195392644088edcb</Hash>
</Codenesium>*/