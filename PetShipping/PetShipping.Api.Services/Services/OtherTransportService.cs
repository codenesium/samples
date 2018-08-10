using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>52f18d952f065263c86fefd5e1197e91</Hash>
</Codenesium>*/