using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOClient: AbstractBOClient, IBOClient
	{
		public BOClient(
			ILogger<ClientRepository> logger,
			IClientRepository clientRepository,
			IApiClientModelValidator clientModelValidator)
			: base(logger, clientRepository, clientModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>844042d2d23b2a6d7c0fe801a58e3fa6</Hash>
</Codenesium>*/