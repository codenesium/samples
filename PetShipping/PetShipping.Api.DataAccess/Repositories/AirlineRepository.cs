using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public partial class AirlineRepository : AbstractAirlineRepository, IAirlineRepository
	{
		public AirlineRepository(
			ILogger<AirlineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>904b9d1a60981f8e98e7334b50e909cc</Hash>
</Codenesium>*/