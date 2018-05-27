using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALOtherTransportMapper
	{
		void MapDTOToEF(
			int id,
			DTOOtherTransport dto,
			OtherTransport efOtherTransport);

		DTOOtherTransport MapEFToDTO(
			OtherTransport efOtherTransport);
	}
}

/*<Codenesium>
    <Hash>cf855b49d91e13f3b6589b2b9af7fd36</Hash>
</Codenesium>*/