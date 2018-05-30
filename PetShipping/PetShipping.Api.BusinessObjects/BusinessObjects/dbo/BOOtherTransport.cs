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
	public class BOOtherTransport: AbstractBOOtherTransport, IBOOtherTransport
	{
		public BOOtherTransport(
			ILogger<OtherTransportRepository> logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper otherTransportMapper)
			: base(logger, otherTransportRepository, otherTransportModelValidator, otherTransportMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>c879a870095e86e2b2dc7b84087cd965</Hash>
</Codenesium>*/