using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class OtherTransportRepository : AbstractOtherTransportRepository, IOtherTransportRepository
	{
		public OtherTransportRepository(
			ILogger<OtherTransportRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>81342bfd93769a1c9d8afb36e2fcd2ad</Hash>
</Codenesium>*/