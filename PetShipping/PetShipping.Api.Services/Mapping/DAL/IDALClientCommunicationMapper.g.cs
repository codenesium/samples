using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALClientCommunicationMapper
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
    <Hash>8c1bf99384bc9bbdde87dfd8959fe86a</Hash>
</Codenesium>*/