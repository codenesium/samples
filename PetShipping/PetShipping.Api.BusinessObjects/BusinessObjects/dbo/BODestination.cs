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
	public class BODestination: AbstractBODestination, IBODestination
	{
		public BODestination(
			ILogger<DestinationRepository> logger,
			IDestinationRepository destinationRepository,
			IApiDestinationModelValidator destinationModelValidator)
			: base(logger, destinationRepository, destinationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>29b285ae23448a1353352e27da77a91a</Hash>
</Codenesium>*/