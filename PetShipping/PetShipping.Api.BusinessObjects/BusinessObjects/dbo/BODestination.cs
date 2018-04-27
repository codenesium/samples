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
			IDestinationModelValidator destinationModelValidator)
			: base(logger, destinationRepository, destinationModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>2f750ba242be05ef6b7097096ce0d8d8</Hash>
</Codenesium>*/