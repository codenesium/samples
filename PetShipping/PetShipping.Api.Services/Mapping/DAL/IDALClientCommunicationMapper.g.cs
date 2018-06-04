using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALClientCommunicationMapper
	{
		ClientCommunication MapBOToEF(
			BOClientCommunication bo);

		BOClientCommunication MapEFToBO(
			ClientCommunication efClientCommunication);

		List<BOClientCommunication> MapEFToBO(
			List<ClientCommunication> records);
	}
}

/*<Codenesium>
    <Hash>ef024a5d9a3ea75073fd4f008ce453c7</Hash>
</Codenesium>*/