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
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper destinationMapper)
			: base(logger, destinationRepository, destinationModelValidator, destinationMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>2e61313d1fbb096a0fbbe3a1d0d5125a</Hash>
</Codenesium>*/