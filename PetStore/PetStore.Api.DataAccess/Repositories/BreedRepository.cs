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
	public partial class BreedRepository : AbstractBreedRepository, IBreedRepository
	{
		public BreedRepository(
			ILogger<BreedRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fba7e838c836550692f69badf39486e2</Hash>
</Codenesium>*/