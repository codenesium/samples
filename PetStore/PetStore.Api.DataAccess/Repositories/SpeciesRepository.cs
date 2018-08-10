using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>4d009fcd780741334370e8020c3910f2</Hash>
</Codenesium>*/