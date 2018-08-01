using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
	public partial class SpeciesRepository : AbstractSpeciesRepository, ISpeciesRepository
	{
		public SpeciesRepository(
			ILogger<SpeciesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b190f500d4c3ccf03bafe500ae7501a6</Hash>
</Codenesium>*/