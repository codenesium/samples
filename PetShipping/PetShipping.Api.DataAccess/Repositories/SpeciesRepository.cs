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
    <Hash>9605b3c0dd08ad7d48552d6b0d245695</Hash>
</Codenesium>*/