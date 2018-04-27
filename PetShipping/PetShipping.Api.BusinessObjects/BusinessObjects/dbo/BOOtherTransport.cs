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
			IOtherTransportModelValidator otherTransportModelValidator)
			: base(logger, otherTransportRepository, otherTransportModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>20ed5f424dca8f6f8b47db0175395b86</Hash>
</Codenesium>*/