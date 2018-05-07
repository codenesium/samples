using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class ClientRepository: AbstractClientRepository, IClientRepository
	{
		public ClientRepository(
			IObjectMapper mapper,
			ILogger<ClientRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>2ab6d335b0edddca10a63273b2c0d987</Hash>
</Codenesium>*/