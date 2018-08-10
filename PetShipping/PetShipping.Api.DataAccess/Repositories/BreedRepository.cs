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
    <Hash>cd00b59dc29f2a4de983e635d838d852</Hash>
</Codenesium>*/