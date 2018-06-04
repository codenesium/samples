using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class ClientRepository: AbstractClientRepository, IClientRepository
	{
		public ClientRepository(
			ILogger<ClientRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>b1489aabbf8513def5f9b34e6a3d71b4</Hash>
</Codenesium>*/