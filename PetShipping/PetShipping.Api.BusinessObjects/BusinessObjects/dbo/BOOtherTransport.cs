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
			IApiOtherTransportModelValidator otherTransportModelValidator)
			: base(logger, otherTransportRepository, otherTransportModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>441a243b7b3a33de3da831c24e43a3ba</Hash>
</Codenesium>*/