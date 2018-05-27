using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALClientCommunicationMapper
	{
		void MapDTOToEF(
			int id,
			DTOClientCommunication dto,
			ClientCommunication efClientCommunication);

		DTOClientCommunication MapEFToDTO(
			ClientCommunication efClientCommunication);
	}
}

/*<Codenesium>
    <Hash>603dd5afeef24f3cf02cd78220ede617</Hash>
</Codenesium>*/