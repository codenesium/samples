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
			IApiClientRequestModelValidator clientModelValidator,
			IBOLClientMapper clientMapper)
			: base(logger, clientRepository, clientModelValidator, clientMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>02da61c2eaf26c5214560524006d02ae</Hash>
</Codenesium>*/