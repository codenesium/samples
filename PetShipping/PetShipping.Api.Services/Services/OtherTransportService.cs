using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class OtherTransportService: AbstractOtherTransportService, IOtherTransportService
	{
		public OtherTransportService(
			ILogger<OtherTransportRepository> logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper BOLotherTransportMapper,
			IDALOtherTransportMapper DALotherTransportMapper)
			: base(logger, otherTransportRepository,
			       otherTransportModelValidator,
			       BOLotherTransportMapper,
			       DALotherTransportMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>7f17b1c9a61c362d724a07ad61491979</Hash>
</Codenesium>*/