using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>359c0b3eb6272e642d4ffe96a4aa2015</Hash>
</Codenesium>*/