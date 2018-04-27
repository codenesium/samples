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
			IClientModelValidator clientModelValidator)
			: base(logger, clientRepository, clientModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>76a5a7d08f20b7b1e6ca8da9d5d40498</Hash>
</Codenesium>*/