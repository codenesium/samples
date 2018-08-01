using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class OtherTransportService : AbstractOtherTransportService, IOtherTransportService
	{
		public OtherTransportService(
			ILogger<IOtherTransportRepository> logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper bolotherTransportMapper,
			IDALOtherTransportMapper dalotherTransportMapper
			)
			: base(logger,
			       otherTransportRepository,
			       otherTransportModelValidator,
			       bolotherTransportMapper,
			       dalotherTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4d08f77fce6b6a567ede13db23f0ff06</Hash>
</Codenesium>*/